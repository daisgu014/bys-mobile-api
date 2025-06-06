using BYS.Mobile.API.Shared.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BYS.Mobile.API.API.TokenHandlers
{
    public class TokenHandler : Microsoft.IdentityModel.Tokens.TokenHandler
    {
        public override async Task<TokenValidationResult> ValidateTokenAsync(string token, TokenValidationParameters validationParameters)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // SỬA: dùng UTF8 giống hệt lúc tạo token
            validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer   = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(BysMobileAPISetting.Instance.Auth.SecretKey.Trim())
                ),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero 
            };

            var result = await tokenHandler.ValidateTokenAsync(token, validationParameters);
            return result;
        }

    }
}
