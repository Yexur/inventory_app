using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GameTrackerAngV1.Persistance.Core
{
    public class Repository<TEntity> : IRepository<TEntity>
     where TEntity : class, IEntity
    {
        protected DbSet<TEntity> DbSet { get; private set; }

        protected GameTrackerContext GameTrackerContext { get; private set; }

        public Repository(GameTrackerContext context)
        {
            GameTrackerContext = context;
            DbSet = GameTrackerContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return entitiesToInclude.Aggregate((IQueryable<TEntity>)DbSet,
                (current, entityToInclude) => current.Include(entityToInclude));
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity.Id <= 0)
            {
                //new entity - insert in to DB
                DbSet.Add(entity);
            }
            else
            {
                //update to the entity
                GameTrackerContext.Entry(entity).State = EntityState.Modified;
            }

            SaveChange();
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
            SaveChange();
        }

        public virtual void Delete(int id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                Delete(entity);
            }
            SaveChange();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChange();
        }

        public virtual TEntity FindById(int id, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return Find(x => x.Id == id, entitiesToInclude).FirstOrDefault();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return entitiesToInclude.Aggregate(DbSet.Where(predicate),
                (current, entityToInclude) => current.Include(entityToInclude));
        }

        private void SaveChange()
        {
            //todo: later this needs to be turned into a unit of work
            GameTrackerContext.SaveChanges();
        }
    }
}

