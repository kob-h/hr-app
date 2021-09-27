using System;

namespace HR.Persistence.Entities
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? BeginningOfEmployment { get; set; }
        public DateTime? TerminationOfEmployment { get; set; }
        public int AnnualSalaryInUsd { get; set; }

        #region NavigationProperties
        public EmployeeAddress EmployeeAddress { get; set; }
        public Department Department { get; set; }
        #endregion
    }
}
