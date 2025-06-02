namespace BYS.Mobile.API.Shared.Models.Messages.Requests
{
    public class GetByRoomRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string RoomId { get; set; }
    }
}
