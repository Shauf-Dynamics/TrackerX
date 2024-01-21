using TrackerX.Infrastructure;

namespace TrackerX.Services.Infrastructure;

public class ServiceResult
{        
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
