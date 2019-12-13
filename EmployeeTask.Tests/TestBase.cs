using EmployeeTask.Data;
using EmployeeTask.DomainModels;
using EmployeeTask.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Tests
{
    public class TestBase
    {
        protected AppDbContext GetSampleData(string db)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(databaseName: db);

            var options = builder.Options;

            var context = new AppDbContext(options);

            // Get sample data and save them for testing
            var employees = new List<Employee>();
            var dataFactory = new DataFactory();

            employees.Add(dataFactory.GetEmployee(1, "James", "Blunt", DateTime.Now.AddYears(-76)));
            employees.Add(dataFactory.GetEmployee(2, "John", "Snow", DateTime.Now.AddYears(-6)));

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return context;
        }
    }
}
