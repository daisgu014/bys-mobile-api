namespace BYS.Mobile.API.Shared.Models.Messages.Requests
{
    public class MessageRequest
    {
        public string DraftId { get; set; }
        public string UserType { get; set; }
        public IEnumerable<AssetMessageContentRequest> Assets { get; set; }
        public string RoomId { get; set; }
        public MessageContentRequest Content { get; set; }
        public UserMessageRequest User { get; set; }
        public string Type { get; set; }
        public string ActionType { get; set; }

    }
    public class UserMessageRequest
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
