namespace BYS.Mobile.API.Shared.Models
{
    public interface IBaseActionEntity<TKey> : IBaseEntity<TKey>, IDeleteEntity
    {
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
