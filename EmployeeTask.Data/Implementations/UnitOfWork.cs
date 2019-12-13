using EmployeeTask.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(context);
            EmployeeTaskRepository = new EmployeeTaskRepository(context);
        }
        public IEmployeeTaskRepository EmployeeTaskRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
