using Newtonsoft.Json;

namespace BYS.Mobile.API.Shared.Providers.Implements
{
    public class UserIdentityInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
        [JsonProperty("hr_employee_id")]
        public string HrEmployeeId { get; set; }
    }
}
