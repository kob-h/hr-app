using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Application.Dtos
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime BeginningOfEmployment { get; set; }
        public DateTime? TerminationOfEmployment { get; set; }
        public int AnnualSalaryInUsd { get; set; }
        public CreateEmployeeAddressDto EmployeeAddress { get; set; }
    }
}
