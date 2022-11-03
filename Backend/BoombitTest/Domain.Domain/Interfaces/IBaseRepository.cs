using System;
namespace Domain.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> getAll();

        TEntity getById(object id);

        bool add(TEntity entity);

        bool addRange(IEnumerable<TEntity> entites);

        bool update(TEntity entity);

        bool updateRange(IEnumerable<TEntity> entity);

        bool delete(object id);
    }
}

