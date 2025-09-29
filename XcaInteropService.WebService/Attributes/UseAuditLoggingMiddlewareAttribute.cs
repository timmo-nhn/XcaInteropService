namespace XcaXds.WebService.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class UseAuditLoggingMiddlewareAttribute : Attribute
{
    public bool Enabled { get; set; } = true;
}
