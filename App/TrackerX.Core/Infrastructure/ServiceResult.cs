namespace TrackerX.Core.Infrastructure
{
    public class ServiceResult
    {
        public ResultType Result { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public ServiceResult(ResultType resultType)
        {
            Result = resultType;
        }

        public ServiceResult(ResultType resultType, string message)
        {
            Result = resultType;
            ErrorMessage = message;
        }
    }
}
