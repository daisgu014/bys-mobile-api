namespace BYS.Mobile.API.Shared.Models.Rooms.Requests
{
    public class RoomRequest
    {
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string EventId { get; set; }
        public string BoothId { get; set; }
        public string Type { get; set; }
        public string CompanyId { get; set; }
    }
}
