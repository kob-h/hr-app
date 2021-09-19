using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HR.Persistence.Database;
using HR.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        private readonly HRDbContext _context;
        protected readonly DbSet<T> Set;

        public RepositoryBase(HRDbContext context)
        {
            _context = context;
            Set = context.Set<T>();
        }
        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void Update(T entity)
        {
            Set.Remove(entity);
        }

        public virtual IQueryable<T> FindAllBy(Expression<Func<T, bool>> predicate)
        {
            return Set.Where(predicate);
        }


    }
}
