using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMCS.Data.Abstract
{
    public interface IEMCSRepositoryBase<T> where T : class
    {
        int Count(Expression<Func<T, T>> predicate);

        void Delete(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        T GetByID(int id);

        void Save(T entity);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate, String children);
    }
}