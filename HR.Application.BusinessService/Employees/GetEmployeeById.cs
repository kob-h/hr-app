using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Persistence.Database;
using HR.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.BusinessService.Employees
{
    public class GetEmployeeById : IGetEmployeeById
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeById(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Execute(Guid employeeId)
        {
            var employeeEntity = await _employeeRepository
                .FindAllBy(emp => emp.Id == employeeId)
                .SingleOrDefaultAsync();
            
            return _mapper.Map<EmployeeDto>(employeeEntity);
        }
    }
}
