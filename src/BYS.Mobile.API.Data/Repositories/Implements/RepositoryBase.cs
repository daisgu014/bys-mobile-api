using System.Linq.Expressions;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Repositories.Implements;

   // Generic base class for repository pattern implementation.
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IIdentity<TKey> // TEntity must be a class that implements the IIdentity interface.
    {
        protected DbSet<TEntity> _entities; // DbSet representing the collection of entities in the context.

        // Constructor to initialize the repository with the application database context.
        protected RepositoryBase(DbContext dbContext)
        {
            _entities = dbContext.Set<TEntity>(); // Set the DbSet for the entity type.
        }

        // Asynchronously counts the number of entities that match the given expression.
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            // If no expression is provided, count all entities; otherwise, count those matching the expression.
            return await (expression is null ? _entities.CountAsync() : _entities.CountAsync(expression));
        }

        // Asynchronously retrieves an entity by its unique identifier.
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _entities.FindAsync(id); // Finds the entity by its ID asynchronously.
        }

        // Returns a queryable collection of entities that match the specified expression.
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression = null)
        {
            var entities = _entities.AsQueryable(); // Start with all entities.

            // If an expression is provided, filter the entities accordingly.
            if (expression is not null)
            {
                entities = entities.Where(expression);
            }

            return entities; // Return the filtered collection.
        }

        // Asynchronously retrieves a list of entities that match the specified expression.
        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await Find(expression).ToListAsync(); // Convert the IQueryable to a List asynchronously.
        }

        // Asynchronously adds a new entity to the context.
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity); // Add the entity to the DbSet asynchronously.
            return entity; // Return the added entity.
        }

        // Asynchronously adds a range of entities to the context.
        public async Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities); // Add multiple entities to the DbSet asynchronously.
            return entities; // Return the added entities.
        }

        // Updates an existing entity in the context.
        public TEntity Update(TEntity entity)
        {
            _entities.Update(entity); // Mark the entity as modified in the DbSet.
            return entity; // Return the updated entity.
        }

        // Updates a range of entities in the context.
        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities); // Mark multiple entities as modified in the DbSet.
            return entities; // Return the updated entities.
        }

        // Removes a range of entities from the context.
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities); // Remove the specified entities from the DbSet.
        }

        // Removes entities that match the specified expression from the context.
        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entities = Find(expression); // Find the entities matching the expression.
            _entities.RemoveRange(entities); // Remove the found entities from the DbSet.
        }

        // Removes a specific entity from the context.
        public void Delete(TEntity entity)
        {
            _entities.Remove(entity); // Remove the specified entity from the DbSet.
        }

        // Asynchronously retrieves the first entity that matches the specified expression or null if none is found.
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            // If no expression is provided, return the first entity; otherwise, return the first that matches the expression.
            return await (expression is null ? _entities.FirstOrDefaultAsync() : _entities.FirstOrDefaultAsync(expression));
        }

        // Asynchronously checks if any entities match the specified expression.
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            // If no expression is provided, check if any entities exist; otherwise, check based on the expression.
            return await (expression is null ? _entities.AnyAsync() : _entities.AnyAsync(expression));
        }
    }