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
        int Count();

        int Count(Expression<Func<T, T>> predicate);

        void Delete(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);

        T GetByID(int id);

        void Save(T entity);

        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Search(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        void Update(T entity);
    }
}