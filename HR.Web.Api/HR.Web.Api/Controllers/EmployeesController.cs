using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Persistence.Database;
using HR.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using EmployeeDto = HR.Application.Dtos.EmployeeDto;
using EmployeeAddressDto = HR.Application.Dtos.CreateEmployeeAddressDto;

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
        public async Task<IActionResult> GetAll([FromServices] IGetAllEmployees gerGetAllEmployees)
        {
            var employees = await gerGetAllEmployees.Execute();
            return Ok(employees);
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id, [FromServices] IGetEmployeeById getEmployeeById)
        {
            var employee = getEmployeeById.Execute(id);
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
        public async Task<IActionResult> Add(
            [FromBody] CreateEmployeeDto addEmployeeDto,
            [FromServices] ICreateEmployee addEmployee)
        {
            var employeeDto = await addEmployee.Execute(addEmployeeDto);

            return CreatedAtAction($"{nameof(GetById)}", new { employeeId = employeeDto.Id}, employeeDto);
        }

        
    }
}
