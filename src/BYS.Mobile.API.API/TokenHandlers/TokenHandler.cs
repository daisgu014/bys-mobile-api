using BYS.Mobile.API.Shared.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BYS.Mobile.API.API.TokenHandlers
{
    public class TokenHandler : Microsoft.IdentityModel.Tokens.TokenHandler
    {
        public override async Task<TokenValidationResult> ValidateTokenAsync(string token, TokenValidationParameters validationParameters)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(BysMobileAPISetting.Instance.Auth.SecretKey)),
            };

            var result = await tokenHandler.ValidateTokenAsync(token, validationParameters);
            return result;
        }
    }
}
