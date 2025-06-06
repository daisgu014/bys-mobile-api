using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Business.Abstractions;

public interface IAduserBusiness : IBusiness
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<LoginResponse> RefreshTokenAsync(string refreshToken);
}