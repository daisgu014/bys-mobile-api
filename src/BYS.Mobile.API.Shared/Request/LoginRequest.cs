using System.ComponentModel.DataAnnotations;

namespace BYS.Mobile.API.Shared.Request;

public class LoginRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}