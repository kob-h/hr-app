using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Persistence.Database;
using HR.Persistence.Repositories.Interfaces;
using EmployeeEntity = HR.Persistence.Entities.Employee;
using EmployeeAddressEntity = HR.Persistence.Entities.EmployeeAddress;

namespace HR.Application.BusinessService.Employees
{
    public class CreateEmployee : ICreateEmployee
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployee(
            IEmployeeRepository employeeRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Execute(CreateEmployeeDto addEmployee)
        {
            var employeeEntity = _mapper.Map<EmployeeEntity>(addEmployee);
            _employeeRepository.Add(employeeEntity);

            await _unitOfWork.CommitAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeDto;
        }
    }
}
