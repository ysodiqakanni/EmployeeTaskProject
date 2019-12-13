using EmployeeTask.Data.Implementations;
using EmployeeTask.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeTask.Tests
{
    public class RepositoryTests : TestBase
    {

        [Fact]
        public void GetAll_Test()
        {
            using (var context = GetSampleData(nameof(GetAll_Test)))
            {
                // Arrange
                var _unitOfWork = new UnitOfWork(context);

                // Act
                var employees = _unitOfWork.EmployeeRepository.GetAll();

                // Assert
                Assert.Equal(2, employees.Count());
            }
        }

        [Fact]
        public void Add_Test()
        {
            using (var context = GetSampleData(nameof(Add_Test)))
            {
                // Arrange
                var uow = new UnitOfWork(context);

                var dataFactory = new DataFactory();

                // Act
                // add a new employee to make 3
                var employee = dataFactory.GetEmployee(3, "Tony", "Black", DateTime.Now);
                uow.EmployeeRepository.Add(employee);
                uow.Complete();
                var allEmployees = uow.EmployeeRepository.GetAll();

                // Assert
                Assert.Equal("Tony", employee.FirstName);
                Assert.Equal(3, allEmployees.Count());
            }
        }


        [Fact]
        public void Update_Test()
        {
            using (var context = GetSampleData(nameof(Update_Test)))
            {
                // Arrange
                var uow = new UnitOfWork(context); 

                // Act
                var emp = uow.EmployeeRepository.Get(1);
                emp.FirstName = "modified";
                uow.EmployeeRepository.UpdateAsync(emp, 1);
                uow.Complete();

                var updated = uow.EmployeeRepository.Get(1);

                // Assert
                Assert.Equal("modified", updated.FirstName);
            }
        }

        [Fact]
        public void Delete_Test()
        {
            using (var context = GetSampleData(nameof(Delete_Test)))
            {
                // Arrange
                var uow = new UnitOfWork(context); 

                // Act
                var emp = uow.EmployeeRepository.Get(1); 

                uow.EmployeeRepository.DeleteAsync(emp);
                uow.Complete();
                var remainingEmployees = uow.EmployeeRepository.GetAll();

                // Assert
                Assert.Single(remainingEmployees);
            }
        }

    }
}
