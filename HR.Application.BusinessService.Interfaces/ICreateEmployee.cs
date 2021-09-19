using System;
using System.Threading.Tasks;
using HR.Application.Dtos;

namespace HR.Application.BusinessService.Interfaces
{
    public interface ICreateEmployee
    {
        Task<EmployeeDto> Execute(CreateEmployeeDto addEmployee);
    }
}
