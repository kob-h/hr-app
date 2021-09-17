using System;
using HR.Common.Enumerations;

namespace HR.Application.Dtos
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DepartmentCodes Code { get; set; }
        public string Manager { get; set; }
    }
}
