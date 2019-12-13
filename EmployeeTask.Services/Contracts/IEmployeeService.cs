using EmployeeTask.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Services.Contracts
{
    public interface IEmployeeService
    {
        Employee CreateNewEmployee(Employee employee);
        List<Employee> GetAll();
        Employee GetEmployeeById(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
