using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HR.Persistence.Entities;

namespace HR.Persistence.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T :  EntityBase
    {
        Task<T> GetById(Guid id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> FindAllBy(Expression<Func<T, bool>> predicate);
    }
}
