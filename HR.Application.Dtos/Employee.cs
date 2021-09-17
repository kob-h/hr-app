using System;

namespace HR.Application.Dtos
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime BeginningOfEmployment { get; set; }
        public DateTime? TerminationOfEmployment { get; set; }
        public int AnnualSalaryInUsd { get; set; }
        public EmployeeAddress EmployeeAddress { get; set; }

    }
}
