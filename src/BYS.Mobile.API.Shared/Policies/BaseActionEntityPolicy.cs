using BYS.Mobile.API.Shared.Models;
using BYS.Mobile.API.Shared.Policies;

namespace BYS.Mobile.API.Shared.Policies
{
    public class BaseActionEntityPolicy<T, TKey> : IUpdatePolicy<T> where T : IBaseActionEntity<TKey>
    {
        public virtual void PrepareUpdate(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
