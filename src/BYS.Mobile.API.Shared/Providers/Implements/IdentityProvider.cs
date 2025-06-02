using BYS.Mobile.API.Shared.Extensions;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using System.Security.Claims;

namespace BYS.Mobile.API.Shared.Providers.Implements
{
    public class IdentityProvider : IIdentityProvider
    {
        public IdentityInfo Identity { get; set; } = new IdentityInfo();

        public void UpdateIdentity(ClaimsPrincipal user)
        {
            var json = user.FindFirstValue("user");

            if (!string.IsNullOrWhiteSpace(json))
            {
                Identity.UserIdentity = json.TryDeserializeObject<UserIdentityInfo>();
            }
            else
            {
                Identity.UserIdentity = new UserIdentityInfo()
                {
                    Id = user.FindFirstValue("userId"),
                    Email = user.FindFirstValue("email"),
                    Username = user.FindFirstValue("userName"),
                    FirstName = user.FindFirstValue("firstName"),
                    LastName = user.FindFirstValue("lastName")
                };
            }
        }
    }
}
