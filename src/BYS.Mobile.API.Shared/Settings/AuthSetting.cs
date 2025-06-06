namespace BYS.Mobile.API.Shared.Settings
{
    /// <summary>
    /// Cấu hình xác thực và phát hành JWT.
    /// </summary>
    public class AuthSetting
    {
        /// <summary>
        /// Có đang chạy môi trường production không (dùng cho xác thực HTTPS, redirect, v.v.).
        /// </summary>
        public bool IsProdEnv { get; set; }

        /// <summary>
        /// Khóa bí mật dùng để ký JWT (HMAC SHA256).
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Tên đơn vị phát hành token (issuer).
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Đối tượng nhận token (audience).
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Thời gian sống của access token (tính theo ngày).
        /// </summary>
        public int ExpiryTimeInDays { get; set; }

        /// <summary>
        /// Thời gian sống của access token (tính theo giờ, nếu cần dùng thay cho theo ngày).
        /// </summary>
        public int ExpiryTimeInHours { get; set; }

        /// <summary>
        /// Thời gian sống của refresh token (tính theo ngày).
        /// </summary>
        public int RefreshTokenExpiryInDays { get; set; }
    }
}