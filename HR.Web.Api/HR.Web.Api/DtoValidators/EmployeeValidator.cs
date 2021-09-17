using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HR.Application.Dtos;

namespace HR.Web.Api.DtoValidators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.AnnualSalaryInUsd).GreaterThan(0);
            RuleFor(x => x.BeginningOfEmployment).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.EmployeeAddress).SetValidator(new EmployeeAddressValidator());
        }
    }
}
