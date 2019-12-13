using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.DomainModels
{
    public class Employee : BaseEntity
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }

        public virtual List<EmployeeTask> EmployeeTasks { get; set; } 
    }
}
