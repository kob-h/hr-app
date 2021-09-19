using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Persistence.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> FindAllBy(Expression<Func<T, bool>> predicate);
    }
}
