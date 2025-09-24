namespace XcaInteropService.Commons.Extensions;

public static class GlobalExtensions
{
    public static bool TryThis(Action action)
    {
        try
        {
            action();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}