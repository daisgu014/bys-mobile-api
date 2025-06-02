using BYS.Mobile.API.Shared.Contents.Resources;
using BYS.Mobile.API.Shared.Enums;

namespace BYS.Mobile.API.Shared.Exceptions
{
    public interface IResultException
    {
        object Result { get; }
    }

    public class DomainException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public int? SubErrorCode { get; set; }
        public string SubErrorCodeString { get; set; }

        public DomainException(ErrorCode errorCode, string message = null, int? subErrorCode = null, string subErrorCodeString = null, params string[] args)
            : base(GetErrorMessage(errorCode, subErrorCode, ref subErrorCodeString, message, args))
        {
            ErrorCode = errorCode;
            SubErrorCode = subErrorCode;
            SubErrorCodeString = subErrorCodeString;
        }

        private static string GetErrorMessage(ErrorCode errorCode, int? subErrorCode, ref string subErrorCodeString, string message, string[] args)
        {
            var errorMessage = message;

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                if (subErrorCode.HasValue && Enum.IsDefined(typeof(SubErrorCode), subErrorCode))
                {
                    subErrorCodeString = ((SubErrorCode)subErrorCode).ToString();
                    errorMessage = ErrorMessage.ResourceManager.GetString(subErrorCodeString);
                }
                else
                {
                    errorMessage = ErrorMessage.ResourceManager.GetString(errorCode.ToString());
                }
            }

            return args?.Any() ?? false ? string.Format(errorMessage, args) : errorMessage;
        }
    }

    public class DomainException<T> : DomainException, IResultException
    {
        public object Result => ResponseData;
        public T ResponseData { get; set; }

        public DomainException(ErrorCode errorCode, T responseData, string message = null, int? subErrorCode = null, string subErrorCodeString = null, params string[] args) : base(errorCode, message, subErrorCode, subErrorCodeString, args)
        {
            ResponseData = responseData;
        }
    }
}
