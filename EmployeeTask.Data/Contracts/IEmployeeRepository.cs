using EmployeeTask.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Data.Contracts
{ 
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }
}
