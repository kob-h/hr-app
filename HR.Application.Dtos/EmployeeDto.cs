using System;

namespace HR.Application.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime BeginningOfEmployment { get; set; }
        public DateTime? TerminationOfEmployment { get; set; }
        public int AnnualSalaryInUsd { get; set; }
        public EmployeeAddressDto EmployeeAddress { get; set; }

    }
}
