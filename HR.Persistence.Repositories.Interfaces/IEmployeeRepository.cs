using System;
using System.Collections.Generic;
using System.Linq;
using HR.Persistence.Entities;

namespace HR.Persistence.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IQueryable<Employee> GetAllCurrentlyEmployedEmployees();
    }
}
