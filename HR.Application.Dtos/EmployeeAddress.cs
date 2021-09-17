using System;

namespace HR.Application.Dtos
{
    public class EmployeeAddress
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

    }
}
