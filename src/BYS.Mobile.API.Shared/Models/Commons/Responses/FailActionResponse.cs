namespace BYS.Mobile.API.Shared.Models.Commons.Responses
{
    public class FailActionResponse : ActionResponse
    {
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public int? SubErrorCode { get; set; }
        public string ErrorCodeString { get; set; }
        public string SubErrorCodeString { get; set; }

        public FailActionResponse(int errorCode, string errorCodeString)
        {
            ErrorCode = errorCode;
            ErrorCodeString = errorCodeString;
        }

        public FailActionResponse() { }
    }

    public class FailActionResponse<T> : FailActionResponse, IResultActionResponse<T>
    {
        public T Data { get; set; }
    }
}
