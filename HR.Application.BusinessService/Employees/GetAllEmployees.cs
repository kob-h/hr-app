using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Persistence.Database;
using HR.Persistence.Entities;
using HR.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.BusinessService.Employees
{
    public class GetAllEmployees : IGetAllEmployees
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployees(
            IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeDto>> Execute()
        {
            var employeesEntity = await _employeeRepository
                .GetAllCurrentlyEmployedEmployees()
                .ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(employeesEntity);
        }
    }
}
