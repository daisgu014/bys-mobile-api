using BYS.Mobile.API.Shared.Providers.Implements;
using System.Security.Claims;

namespace BYS.Mobile.API.Shared.Providers.Abstractions
{
    public interface IIdentityProvider
    {
        IdentityInfo Identity { get; set; }
        void UpdateIdentity(ClaimsPrincipal user);
    }
}
