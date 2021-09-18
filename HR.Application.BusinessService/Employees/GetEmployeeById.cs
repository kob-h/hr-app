using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.BusinessService.Employees
{
    public class GetEmployeeById : IGetEmployeeById
    {
        private readonly HRDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeById(
            HRDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Execute(Guid employeeId)
        {
            var employeeEntity = await _context.Employees.SingleOrDefaultAsync(emp => emp.Id == employeeId);
            
            return _mapper.Map<EmployeeDto>(employeeEntity);
        }
    }
}
