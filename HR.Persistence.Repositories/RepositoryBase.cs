using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HR.Persistence.Database;
using HR.Persistence.Entities;
using HR.Persistence.Repositories.Interfaces;
using Infrastructure.Abstractions;
using Infrastructure.Redis;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: EntityBase
    {
        private readonly HRDbContext _context;
        private readonly ICacheService _redisOperationManager;
        protected readonly DbSet<T> Set;

        public RepositoryBase(HRDbContext context, ICacheService redisOperationManager)
        {
            _context = context;
            _redisOperationManager = redisOperationManager;
            Set = context.Set<T>();
        }
        
        public async Task<T> GetById(Guid id)
        {
            var entity = await _redisOperationManager.GetDeserializedValueAsync<T>(id.ToString());
            if (entity == null)
            {
                entity = Set.SingleOrDefault(e => e.Id == id);
            }

            if (entity != null)
            {
                //todo: get the expiry time from a config file
                await _redisOperationManager.SetObjectValueAsync(id.ToString(), entity, TimeSpan.FromHours(2));
            }
            
            return entity;
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
