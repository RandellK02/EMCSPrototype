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

        public EMCSRepositoryBase(EMCSEntities context)
        {
            this.context = context;
        }

        public int Count(Expression<Func<T, T>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>();
            return includes
                .Aggregate(
                    query.AsQueryable(),
                    (current, include) => current.Include( include )
                );
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where( predicate );
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate, String children)
        {
            return context.Set<T>().Include( children ).Where( predicate );
        }
    }
}