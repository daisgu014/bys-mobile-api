namespace BYS.Mobile.API.Shared.Models
{
    public interface IIdentity<TKey>
    {
        TKey Id { get; set; }
    }
}
