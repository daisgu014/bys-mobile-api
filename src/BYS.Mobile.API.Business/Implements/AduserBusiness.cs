using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Response;
using Microsoft.IdentityModel.Tokens;

namespace BYS.Mobile.API.Business.Implements;

public class AduserBusiness : BusinessBase, IAduserBusiness
{
    private readonly IAduserService _userService;
    public AduserBusiness(ICoreProvider coreProvider
        , IAduserService userService
        , IUnitOfWorkService unitOfWorkService) : base(coreProvider, unitOfWorkService)
    {
        _userService = userService;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        if (string.IsNullOrWhiteSpace(loginRequest.Username) || 
            string.IsNullOrWhiteSpace(loginRequest.Password))
        {
            throw new ArgumentException("Username và Password không được để trống");
        }

        var user = await ValidateUserAsync(loginRequest.Username, loginRequest.Password);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Tên đăng nhập hoặc mật khẩu không đúng");
        }

        var tokenString = GenerateToken(user);

        var expiresAt = DateTime.UtcNow.AddDays(_coreProvider.Setting.Auth.ExpiryTimeInDays);

        return new LoginResponse
        {
            AccessToken = tokenString,
            ExpiresAt   = expiresAt
        };
    }
    private async Task<Aduser> ValidateUserAsync(string username, string password)
    {
        // 1. Tìm user theo username
        var user = await _userService
            .FirstOrDefaultAsync(u => u.AduserName == username);

        if (user == null)
            return null;

        string hashedPassword;
        using (var sha1 = SHA1.Create())
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            var hash  = sha1.ComputeHash(bytes);
            hashedPassword = Convert.ToBase64String(hash);
        }
        if (!string.Equals(hashedPassword, user.Adpassword, StringComparison.Ordinal))
            return null;
        return user;
    }
    private string GenerateToken(Aduser user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.AduserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("id", user.AduserId.ToString()),
            new Claim("HremployeeId", user.FkHremployeeId.ToString()),
            new Claim("username", user.AduserName.ToString())
        };

        var keyBytes = Encoding.UTF8.GetBytes(_coreProvider.Setting.Auth.SecretKey);
        var securityKey = new SymmetricSecurityKey(keyBytes);
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // 3. Thời gian hết hạn
        var expires = DateTime.UtcNow.AddDays(_coreProvider.Setting.Auth.ExpiryTimeInDays);

        // 4. Tạo JwtSecurityToken
        var token = new JwtSecurityToken(
            issuer: _coreProvider.Setting.Auth.Issuer,
            audience: _coreProvider.Setting.Auth.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: creds
        );

        // 5. Chuyển thành string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}