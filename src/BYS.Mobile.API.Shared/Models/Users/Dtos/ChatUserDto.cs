namespace BYS.Mobile.API.Shared.Models.Users.Dtos
{
    public class ChatUserDto
    {
        public string Id { get; set; }
        public IEnumerable<ChatConnectionDto> Connections { get; set; }
    }
}
