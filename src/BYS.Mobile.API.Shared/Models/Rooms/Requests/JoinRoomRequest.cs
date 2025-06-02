namespace BYS.Mobile.API.Shared.Models.Rooms.Requests
{
    public class JoinRoomRequest
    {
        public string BoothId { get; set; }
        public string RoomId { get; set; }
        public string ConnectionId { get; set; }
    }
}
