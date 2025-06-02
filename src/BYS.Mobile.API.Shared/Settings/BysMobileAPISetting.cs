using Confluent.Kafka;

namespace BYS.Mobile.API.Shared.Settings
{
    public class BysMobileAPISetting
    {
        public static BysMobileAPISetting Instance { get; set; }
        public AuthSetting Auth { get; set; }
        public bool IsDisableMigration { get; set; }
       
    }
}
