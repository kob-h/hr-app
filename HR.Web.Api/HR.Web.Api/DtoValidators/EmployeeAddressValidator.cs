using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HR.Application.Dtos;

namespace HR.Web.Api.DtoValidators
{
    public class EmployeeAddressValidator : AbstractValidator<EmployeeAddress>
    {
        public EmployeeAddressValidator()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
        }
    }
}
