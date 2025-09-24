using XcaInteropService.Commons.Models.Soap;
namespace XcaInteropService.Commons.Commons;

public class SoapRequestResult<T>
{
    public bool IsSuccess { get; set; }
    public T? Value { get; set; }
    public Fault? FaultResult { get; set; }


    public SoapRequestResult<T> Success(T result)
    {
        var soapResult = new SoapRequestResult<T>
        {
            IsSuccess = true,
            Value = result
        };

        return soapResult;
    }

    public SoapRequestResult<T> Fault(T fault)
    {
        var soapResult = new SoapRequestResult<T>
        {
            IsSuccess = false,
            Value = fault,
        };

        return soapResult;
    }
}
