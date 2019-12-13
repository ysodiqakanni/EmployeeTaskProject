using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        IEmployeeTaskRepository EmployeeTaskRepository { get; set; }

        int Complete();
    }
}
