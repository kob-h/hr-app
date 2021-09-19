using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HR.Persistence.Database;
using HR.Persistence.Entities;
using HR.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HRDbContext context) : base(context)
        {
            
        }
        public IQueryable<Employee> GetAllCurrentlyEmployedEmployees()
        {
            return FindAllBy(emp => !emp.TerminationOfEmployment.HasValue)
                .Include(emp => emp.EmployeeAddress)
                ;
        }

        public override IQueryable<Employee> FindAllBy(Expression<Func<Employee, bool>> predicate)
        {
            return base.FindAllBy(predicate).Include(emp => emp.EmployeeAddress);
        }
    }
}
