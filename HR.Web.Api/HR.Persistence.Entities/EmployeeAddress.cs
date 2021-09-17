using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Persistence.Entities
{
    public class EmployeeAddress
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public Guid EmployeeId { get; set; }

        #region NavigationProperties
        public virtual Employee Employee { get; set; }
        #endregion
    }
}
