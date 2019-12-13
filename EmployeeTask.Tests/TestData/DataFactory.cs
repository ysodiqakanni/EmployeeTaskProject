using EmployeeTask.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Tests.TestData
{
    public class DataFactory
    {
        public Employee GetEmployee(int id, string firatName, string lastName, DateTime hiredDate)
        {
            var emp = new Employee
            {
                Id = id,
                FirstName = firatName,
                LastName = lastName,
                HiredDate = hiredDate
            };
            return emp;
        }
    }
}
