using Domain.Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected ApiContext context;

        public BaseRepository(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> getAll()
        {
            return this.context.Set<TEntity>();
        }

        public TEntity getById(object id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public bool add(TEntity entity)
        {
            try
            {
                this.context.Set<TEntity>().Add(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool addRange(IEnumerable<TEntity> entities)
        {
            try
            {
                this.context.Set<TEntity>().AddRange(entities);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool update(TEntity entity)
        {
            try
            {
                this.context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool updateRange(IEnumerable<TEntity> entity)
        {
            try
            {
                this.context.Set<TEntity>().UpdateRange(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex){return false;}
        }

        public bool delete(object id)
        {
            try
            {
                var entity = this.context.Set<TEntity>().Find(id);
                this.context.Set<TEntity>().Remove(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}

