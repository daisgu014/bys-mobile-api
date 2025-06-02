using BYS.Mobile.API.Shared.Models;
using System.Linq.Expressions;

namespace BYS.Mobile.API.Data.Repositories.Abtractions
{
    public interface IRepository<TEntity, TKey> where TEntity : IIdentity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id); // Retrieves an entity by its ID.

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null); // Returns the first matching entity or null.

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression = null); // Returns a queryable collection of entities matching the expression.

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression = null); // Asynchronously retrieves a list of entities matching the expression.

        Task<TEntity> InsertAsync(TEntity entity); // Asynchronously inserts a new entity.

        Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities); // Asynchronously inserts a range of entities.

        TEntity Update(TEntity entity); // Updates an existing entity.

        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities); // Updates a range of entities.

        void DeleteRange(IEnumerable<TEntity> entities); // Deletes a range of entities.

        void Delete(Expression<Func<TEntity, bool>> expression); // Deletes entities matching the expression.

        void Delete(TEntity entity); // Deletes a specific entity.

        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null); // Asynchronously counts entities matching the expression.

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null); // Asynchronously checks if any entities match the expression.
    }
}
