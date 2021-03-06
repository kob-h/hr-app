using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.Application.Dtos;

namespace HR.Application.BusinessService.Interfaces
{
    public interface IGetEmployeeById
    {
        Task<EmployeeDto> Execute(Guid employeeId);
    }
}
