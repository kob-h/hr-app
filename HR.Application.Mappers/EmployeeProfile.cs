using System;
using AutoMapper;
using HR.Application.Dtos;
using HR.Persistence.Entities;

namespace HR.Application.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
