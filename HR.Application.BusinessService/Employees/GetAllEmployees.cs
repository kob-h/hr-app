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
using Microsoft.EntityFrameworkCore;

namespace HR.Application.BusinessService.Employees
{
    public class GetAllEmployees : IGetAllEmployees
    {
        private readonly HRDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployees(
            HRDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Execute()
        {
            var employeesEntity = await _context.Employees
                .Include(emp => emp.EmployeeAddress)
                .ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(employeesEntity);
        }
    }
}
