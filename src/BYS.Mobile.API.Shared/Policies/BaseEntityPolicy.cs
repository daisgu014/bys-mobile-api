using BYS.Mobile.API.Shared.Models;

namespace BYS.Mobile.API.Shared.Policies
{
    public class BaseEntityPolicy<T, TKey> : IInsertPolicy<T> where T : IBaseEntity<TKey>
    {
        public virtual void PrepareInsert(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
        }
    }
}
