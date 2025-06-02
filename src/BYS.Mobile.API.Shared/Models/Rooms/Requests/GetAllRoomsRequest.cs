using BYS.Mobile.API.Share.Request;

namespace BYS.Mobile.API.Shared.Models.Rooms.Requests
{
    public class GetAllRoomsRequest : BaseGetAllRequest
    {
        public List<string> EventId { get; set; }
        public List<string> BoothId { get; set; }
    }
}
