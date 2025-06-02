namespace BYS.Mobile.API.Shared.Models.Messages.Dtos
{
    public class MessageDto
    {
        public string DraftId { get; set; }
        public string UserType { get; set; }
        public IEnumerable<AssetMessageContentDto> Assets { get; set; }
        public DateTime SendTime { get; set; }
        public string UserId { get; set; }
        public string RoomId { get; set; }
        public MessageContentDto Content { get; set; }
        public IEnumerable<ViewerDto> Viewers { get; set; }
        public bool IsDeleted { get; set; }
        public UserMessageDto User { get; set; }
        public string Type { get; set; }
        public string ActionType { get; set; }
    }
    public class UserMessageDto
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
