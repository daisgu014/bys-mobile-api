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
        var refreshToken = GenerateRefreshToken(user);
        var expiresAt = DateTime.UtcNow.AddDays(_coreProvider.Setting.Auth.ExpiryTimeInDays);

        return new LoginResponse
        {
            AccessToken  = tokenString,
            RefreshToken = refreshToken,
            ExpiresAt    = expiresAt
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
            new Claim("hr_employee_id", user.FkHremployeeId.ToString()),
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
    private string GenerateRefreshToken(Aduser user)
    {
        var issuedAtTicks = DateTime.UtcNow.Ticks;
        var payload = $"{user.AduserId}|{issuedAtTicks}";
        var keyBytes = Encoding.UTF8.GetBytes(_coreProvider.Setting.Auth.SecretKey);

        using var hmac = new HMACSHA256(keyBytes);
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        var hashBase64 = Convert.ToBase64String(hashBytes);

        var token = $"{user.AduserId}|{issuedAtTicks}|{hashBase64}";
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(token)); // <-- encode toàn bộ
    }

    public async Task<LoginResponse> RefreshTokenAsync(string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
            throw new UnauthorizedAccessException("Refresh token không hợp lệ");

        string decoded;
        try
        {
            decoded = Encoding.UTF8.GetString(Convert.FromBase64String(refreshToken));
        }
        catch
        {
            throw new UnauthorizedAccessException("Refresh token sai định dạng");
        }

        var parts = decoded.Split('|');
        if (parts.Length != 3)
            throw new UnauthorizedAccessException("Cấu trúc token không hợp lệ");

        if (!int.TryParse(parts[0], out var userId) || !long.TryParse(parts[1], out var ticks))
            throw new UnauthorizedAccessException("Dữ liệu token không hợp lệ");

        var signature = parts[2];
        var issuedAt = new DateTime(ticks, DateTimeKind.Utc);
        var expireTime = issuedAt.AddDays(_coreProvider.Setting.Auth.RefreshTokenExpiryInDays);
        if (DateTime.UtcNow > expireTime)
            throw new UnauthorizedAccessException("Refresh token đã hết hạn");

        var user = await _userService.FirstOrDefaultAsync(x => x.AduserId == userId);
        if (user == null)
            throw new UnauthorizedAccessException("Không tìm thấy user");

        // Tạo lại HMAC
        var payload = $"{user.AduserId}|{ticks}";
        var keyBytes = Encoding.UTF8.GetBytes(_coreProvider.Setting.Auth.SecretKey);
        using var hmac = new HMACSHA256(keyBytes);
        var expectedSig = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(payload)));

        if (!string.Equals(signature, expectedSig))
            throw new UnauthorizedAccessException("Refresh token không hợp lệ hoặc đã bị thay đổi");

        return new LoginResponse
        {
            AccessToken = GenerateToken(user),
            RefreshToken = GenerateRefreshToken(user),
            ExpiresAt = DateTime.UtcNow.AddDays(_coreProvider.Setting.Auth.ExpiryTimeInDays)
        };
    }

}