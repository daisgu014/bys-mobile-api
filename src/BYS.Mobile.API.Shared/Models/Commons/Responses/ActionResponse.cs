namespace BYS.Mobile.API.Shared.Models.Commons.Responses
{
    public interface IResultActionResponse<T>
    {
        T Data { get; set; }
    }

    public class ActionResponse
    {
        public bool IsSucceeded { get; set; }
    }

    public class ActionResponse<T> : ActionResponse, IResultActionResponse<T>
    {
        public T Data { get; set; }
    }
}
