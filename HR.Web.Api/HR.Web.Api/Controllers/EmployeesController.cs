using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Application.Dtos;
using HR.Persistence.Database;
using HR.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using EmployeeDto = HR.Application.Dtos.Employee;
using EmployeeAddressDto = HR.Application.Dtos.EmployeeAddress;
using EmployeeEntity = HR.Persistence.Entities.Employee;
using EmployeeAddressEntity = HR.Persistence.Entities.EmployeeAddress;

namespace HR.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HRDbContext _context;

        public EmployeesController(HRDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok();
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(emp => emp.Id == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] EmployeeDto employee)
        {
            var employeeEntity = MapEmployeeDtoToEntity(employee);
            
            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"{nameof(GetById)}", new { employeeId = employeeEntity.Id}, employee);
        }

        private EmployeeEntity MapEmployeeDtoToEntity(EmployeeDto employeeDto)
        {
            return new EmployeeEntity()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BeginningOfEmployment = employeeDto.BeginningOfEmployment,
                DateOfBirth = employeeDto.DateOfBirth,
                AnnualSalaryInUsd = employeeDto.AnnualSalaryInUsd,
                EmployeeAddress = new EmployeeAddressEntity()
                {
                    Country = employeeDto.EmployeeAddress.Country,
                    City = employeeDto.EmployeeAddress.City,
                    PostalCode = employeeDto.EmployeeAddress.PostalCode,
                    Street = employeeDto.EmployeeAddress.Street
                }
            };
        }
    }
}
