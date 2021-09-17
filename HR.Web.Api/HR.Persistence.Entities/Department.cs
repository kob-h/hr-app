using System;
using System.Collections.Generic;
using System.Text;
using HR.Common.Enumerations;

namespace HR.Persistence.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DepartmentCodes Code { get; set; }
        public Guid ManagerId { get; set; }

        #region NavigationProperties
        public virtual Employee Manager { get; set; }
        #endregion
    }
}
