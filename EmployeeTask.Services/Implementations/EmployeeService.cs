using EmployeeTask.Data.Contracts;
using EmployeeTask.DomainModels;
using EmployeeTask.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {

        IUnitOfWork uow;
        public EmployeeService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public Employee CreateNewEmployee(Employee employee)
        {
            if (employee == null)
                throw new Exception("Employee cannot be null");

            uow.EmployeeRepository.Add(employee);
            uow.Complete();
            return employee;
        }
        public List<Employee> GetAll()
        {
            var employees = uow.EmployeeRepository.GetAll().ToList(); 
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            return uow.EmployeeRepository.Get(id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee cannot be null");

            uow.Complete();
            return employee; 
        }
        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new Exception("Employee cannot be null");
            uow.EmployeeRepository.Remove(employee);
            uow.Complete();
        }
    }
}
