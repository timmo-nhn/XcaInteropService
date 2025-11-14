namespace XcaInteropService.Commons.Models.Custom;

public class KeyValueEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Key { get; set; } = "";
    public string Value { get; set; } = "";
}

public static class KeyValueEntryExtensions
{
    public static void AddIfNotInList(this List<KeyValueEntry> keyValues, KeyValueEntry valueEntry)
    {
        if (!keyValues.Any(kvp => kvp.Key == valueEntry.Key))
            keyValues.Add(new KeyValueEntry() { Key = valueEntry.Key, Value = valueEntry.Value });

    }
}