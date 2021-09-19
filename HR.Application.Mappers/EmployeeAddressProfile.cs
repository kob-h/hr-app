using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HR.Application.Dtos;
using HR.Persistence.Entities;

namespace HR.Application.Mappers
{
    public class EmployeeAddressProfile : Profile
    {
        public EmployeeAddressProfile()
        {
            CreateMap<CreateEmployeeAddressDto, EmployeeAddress>();
            CreateMap<EmployeeAddress, EmployeeAddressDto>();
        }
    }
}
