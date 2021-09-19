using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.Persistence.Database;
using HR.Persistence.Repositories.Interfaces;

namespace HR.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _context;

        public UnitOfWork(HRDbContext context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
