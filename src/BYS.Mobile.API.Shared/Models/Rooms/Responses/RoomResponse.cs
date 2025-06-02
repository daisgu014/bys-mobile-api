namespace BYS.Mobile.API.Shared.Models.Rooms.Responses
{
    public class RoomResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EventId { get; set; }
        public string BoothId { get; set; }
        public string OwnerId { get; set; }
        public string Type { get; set; }
        public string CompanyId { get; set; }
        public string LastedMessageId { get; set; }
        public string LastedMessageTime { get; set; }
        public long ChatClientNumbers { get; set; }
    }
}
