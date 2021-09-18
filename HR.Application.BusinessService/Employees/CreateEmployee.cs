using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Persistence.Database;
using EmployeeEntity = HR.Persistence.Entities.Employee;
using EmployeeAddressEntity = HR.Persistence.Entities.EmployeeAddress;

namespace HR.Application.BusinessService.Employees
{
    public class CreateEmployee : ICreateEmployee
    {
        private readonly HRDbContext _context;
        private readonly IMapper _mapper;

        public CreateEmployee(
            HRDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Execute(CreateEmployeeDto addEmployee)
        {
            var employeeEntity = _mapper.Map<EmployeeEntity>(addEmployee);
            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeDto;
        }

        private EmployeeDto MapEntityToDto()
        {
            return new EmployeeDto();
        }
        private EmployeeEntity MapEmployeeDtoToEntity(CreateEmployeeDto addEmployeeDto)
        {
            return new EmployeeEntity()
            {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                BeginningOfEmployment = addEmployeeDto.BeginningOfEmployment,
                DateOfBirth = addEmployeeDto.DateOfBirth,
                AnnualSalaryInUsd = addEmployeeDto.AnnualSalaryInUsd,
                EmployeeAddress = new EmployeeAddressEntity()
                {
                    Country = addEmployeeDto.EmployeeAddress.Country,
                    City = addEmployeeDto.EmployeeAddress.City,
                    PostalCode = addEmployeeDto.EmployeeAddress.PostalCode,
                    Street = addEmployeeDto.EmployeeAddress.Street
                }
            };
        }
    }
}
