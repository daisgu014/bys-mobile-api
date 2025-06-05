namespace BYS.Mobile.API.Shared.Settings
{
    public class AuthSetting
    {
        public bool IsProdEnv  { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryTimeInDays { get; set; }
        public int ExpiryTimeInHours { get; set; }
    }
}
