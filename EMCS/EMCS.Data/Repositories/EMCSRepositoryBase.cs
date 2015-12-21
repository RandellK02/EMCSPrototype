using EMCS.Data.Abstract;
using EMCS.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMCS.Data.Repositories
{
    public class EMCSRepositoryBase<T> : IEMCSRepositoryBase<T> where T : class
    {
        private EMCSEntities context;
        private DbSet<T> dbSet;

        public EMCSRepositoryBase(EMCSEntities context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public int Count(Expression<Func<T, T>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            if ( context.Entry( entity ).State == EntityState.Detached )
            {
                dbSet.Attach( entity );
            }
            dbSet.Remove( entity );
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>();
            return includes
                .Aggregate(
                    query.AsQueryable(),
                    (current, include) => current.Include( include )
                ).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> order,
                                     params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public T GetByID(int id)
        {
            return dbSet.Find( id );
        }

        public void Save(T entity)
        {
            dbSet.Add( entity );
            context.SaveChanges();
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where( filter ).ToList();
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> filter,
                                     params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>();
            return (includes
                .Aggregate(
                    query.AsQueryable(),
                    (current, include) => current.Include( include )
                )).Where( filter ).ToList();
        }

        public void Update(T entity)
        {
            dbSet.Attach( entity );
            context.Entry( entity ).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}