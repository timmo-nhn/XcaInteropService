namespace XcaInteropService.Commons.Models.Custom.RestfulRegistry;


public class RestfulApiResponse
{
    public RestfulApiResponse(bool success)
    {
        Success = success;
    }
    public RestfulApiResponse()
    {
        
    }

    public bool Success { get; set; } = true;

    public List<Error> Errors { get; set; }

    public string Message { get; set; }

    public void AddError(string code, string message)
    {
        Success = false;
        Errors ??= new();
        Errors.Add(new()
        {
            Code = string.IsNullOrWhiteSpace(code) ? null : code,
            Message = string.IsNullOrWhiteSpace(message) ? null : message

        });
    }

    public void SetMessage(string message)
    {
        Message = message;
    }
}

public class Error
{
    public string? Code { get; set; }
    public string? Message { get; set; }
}