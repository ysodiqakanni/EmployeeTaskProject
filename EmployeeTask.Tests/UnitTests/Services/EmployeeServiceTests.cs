using EmployeeTask.Data.Implementations;
using EmployeeTask.DomainModels;
using EmployeeTask.Services.Contracts;
using EmployeeTask.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeTask.Tests.UnitTests.Services
{
    public class EmployeeServiceTests : TestBase
    {
        [Fact]
        public void GetAll_MustReturnAllEmployees()
        {
           
            using (var context = GetSampleData(nameof(GetAll_MustReturnAllEmployees)))
            {
                // Arrange
                var uow = new UnitOfWork(context);
                IEmployeeService svc = new EmployeeService(uow);

                // Act
                var employees = svc.GetAll();

                // Assert
                Assert.Equal(2, employees.Count);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateEmployee_ShouldThrowException_IfEmployeeIsNull()
        {

            using (var context = GetSampleData(nameof(UpdateEmployee_ShouldThrowException_IfEmployeeIsNull)))
            {
                // Arrange
                var uow = new UnitOfWork(context);
                IEmployeeService svc = new EmployeeService(uow);

                var employee = default(Employee);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() => svc.UpdateEmployee(employee));
            }
        }

        [Fact]
        public async Task DeleteEmployee_ShouldThrowException_IfEmployeeIsNull()
        {

            using (var context = GetSampleData(nameof(DeleteEmployee_ShouldThrowException_IfEmployeeIsNull)))
            {
                // Arrange
                var uow = new UnitOfWork(context);
                IEmployeeService svc = new EmployeeService(uow);

                var employee = default(Employee);

                // Assert
                Assert.Throws<Exception>(() => svc.DeleteEmployee(employee));
            }
        }
    }
}
