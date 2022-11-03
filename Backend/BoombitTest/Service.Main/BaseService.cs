using System;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;

namespace Service.Main
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected IBaseRepository<TEntity> baseRepository;

        public BaseService( IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public IEnumerable<TEntity> getAll()
        {
            return this.baseRepository.getAll();
        }

        public TEntity getById(object id)
        {
            return this.baseRepository.getById(id);
        }

        public bool add(TEntity entity)
        {
            return this.baseRepository.add(entity);
        }

        public bool addRange(IEnumerable<TEntity> entities)
        {
            return this.baseRepository.addRange(entities);
        }

        public bool update(TEntity entity)
        {
            return this.baseRepository.update(entity);
        }

        public bool updateRange(IEnumerable<TEntity> entities)
        {
            return this.baseRepository.updateRange(entities);
        }

        public bool delete(object id)
        {
            return this.baseRepository.delete(id);
        }
    }
}

