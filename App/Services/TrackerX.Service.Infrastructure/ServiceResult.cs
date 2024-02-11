using TrackerX.Infrastructure;

namespace TrackerX.Services.Infrastructure;

public class ServiceResult
{
    public static ServiceResult Success { get; } = new ServiceResult(StatusType.Success);

    public static ServiceResult Invalid { get; } = new ServiceResult(StatusType.Invalid);

    public static ServiceResult Failure { get; } = new ServiceResult(StatusType.Failure);
    
    public StatusType Status { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;

    public ServiceResult(StatusType resultType)
    {
        Status = resultType;
    }   

    public ServiceResult(StatusType resultType, string message)
    {
        Status = resultType;
        ErrorMessage = message;
    }
}

public class ServiceResult<T> : ServiceResult
{
    public T Result { get; set; }

    public ServiceResult(StatusType resultType, string message) : base(resultType, message) { }

    public ServiceResult(T result, StatusType resultType) : base(resultType)
    {
        Result = result;
    }        

    public ServiceResult CastToNonGeneric()
    {
        return new ServiceResult(Status, ErrorMessage);
    }
}
