namespace BYS.Mobile.API.Shared.Models
{
    public interface IBaseEntity<TKey> : IIdentity<TKey>
    {
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
    }
}
