using BYS.Mobile.API.Shared.Models;
using System.Linq.Expressions;
using AutoMapper;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Settings;

namespace BYS.Mobile.API.Service.Implements
{
    public abstract class ServiceBase<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IIdentity<TKey>
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        protected readonly BysMobileAPISetting _setting;
        protected readonly IMapper _mapper;
        protected readonly ICoreProvider _coreProvider;

        protected ServiceBase(IRepository<TEntity, TKey> repository,
            ICoreProvider coreProvider)
        {
            _repository = repository;
            _setting = BysMobileAPISetting.Instance;
            _coreProvider = coreProvider;
            _mapper = coreProvider.Mapper;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _repository.CountAsync(expression);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
        

        public void Delete(Expression<Func<TEntity, bool>> expression = null)
        {
            _repository.Delete(expression);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _repository.DeleteRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression = null)
        {
            return _repository.Find(expression);
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _repository.FindAsync(expression);
        }

        public async Task<List<TResponse>> FindAsync<TResponse>(Expression<Func<TEntity, bool>> expression = null)
        {
            var entities = await FindAsync(expression);
            return _mapper.Map<List<TResponse>>(entities);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _repository.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            return await _repository.InsertRangeAsync(entities.ToList());
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            return _repository.UpdateRange(entities.ToList());
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _repository.AnyAsync(expression);
        }
    }

    public abstract class ServiceBase<TEntity, TKey, TResponse> : ServiceBase<TEntity, TKey>, IService<TEntity, TKey, TResponse>
        where TEntity : class, IIdentity<TKey>
        where TResponse : class
    {
        protected ServiceBase(IRepository<TEntity, TKey> repository,
            ICoreProvider coreProvider) : base(repository, coreProvider)
        {
        }

        public async Task<List<TResponse>> FindResponseAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            var entities = await FindAsync(expression);
            return _mapper.Map<List<TResponse>>(entities);
        }

        public async Task<TResponse> FirstOrDefaultResponseAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            var entity = await FirstOrDefaultAsync(expression);
            return entity is null ? null : _mapper.Map<TResponse>(entity);
        }

        public async Task<TResponse> GetResponseByIdAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<TResponse>(entity);
        }
    }
}
