using BYS.Mobile.API.Shared.Models;
using System.Linq.Expressions;

namespace BYS.Mobile.API.Service.Abtractions
{
    public interface IService<TEntity, TKey> where TEntity : IIdentity<TKey>
    {
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> expression = null);
        void Delete(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<TEntity> GetByIdAsync(TKey id);

    }

    public interface IService<TEntity, TKey, TResponse> : IService<TEntity, TKey>
        where TEntity : IIdentity<TKey>
    {
        Task<TResponse> GetResponseByIdAsync(TKey id);
        Task<TResponse> FirstOrDefaultResponseAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<List<TResponse>> FindResponseAsync(Expression<Func<TEntity, bool>> expression = null);
    }

}
