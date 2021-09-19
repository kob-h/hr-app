using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.Persistence.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
