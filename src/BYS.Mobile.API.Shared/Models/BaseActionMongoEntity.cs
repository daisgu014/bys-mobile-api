using BYS.Mobile.API.Shared.Models;

namespace BYS.Mobile.API.Shared.Models
{
    public class BaseActionMongoEntity : BaseMongoEntity, IBaseActionEntity<string>
    {
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
