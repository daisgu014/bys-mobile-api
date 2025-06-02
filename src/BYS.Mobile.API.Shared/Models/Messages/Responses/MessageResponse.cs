namespace BYS.Mobile.API.Shared.Models.Messages.Responses
{
    public class MessageResponse
    {
        public string UserType { get; set; }
        public IEnumerable<AssetMessageContentResponse> Assets { get; set; }
        public DateTime SendTime { get; set; }
        public string UserId { get; set; }
        public MessageContentResponse Content { get; set; }
        public IEnumerable<ViewerResponse> Viewers { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; }
        public string ActionType { get; set; }
        public UserMessageResponse User { get; set; }
    }
    public class UserMessageResponse
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
