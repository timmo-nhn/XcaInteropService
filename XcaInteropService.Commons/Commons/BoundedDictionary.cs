namespace XcaInteropService.Commons.Commons;

public class BoundedDictionary<TKey, TValue>
{
    private readonly int _maxSize;
    private readonly Dictionary<TKey, LinkedListNode<(TKey Key, TValue Value)>> _dict;
    private readonly LinkedList<(TKey Key, TValue Value)> _order;

    public BoundedDictionary(int maxSize = 1000)
    {
        if (maxSize <= 0) throw new ArgumentOutOfRangeException(nameof(maxSize));
        _maxSize = maxSize;
        _dict = new Dictionary<TKey, LinkedListNode<(TKey, TValue)>>();
        _order = new LinkedList<(TKey, TValue)>();
    }

    public void Add(TKey key, TValue value)
    {
        var node = new LinkedListNode<(TKey, TValue)>((key, value));
        _order.AddLast(node);
        _dict[key] = node;

        if (_dict.Count > _maxSize)
        {
            var oldest = _order.First!;
            _order.RemoveFirst();
            _dict.Remove(oldest.Value.Key);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        if (_dict.TryGetValue(key, out var node))
        {
            value = node.Value.Value;
            return true;
        }
        value = default!;
        return false;
    }

    public IEnumerable<KeyValuePair<TKey, TValue>> Items =>
        _order.Select(n => new KeyValuePair<TKey, TValue>(n.Key, n.Value));
}
