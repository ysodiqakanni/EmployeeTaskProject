using EmployeeTask.Data.Contracts;
using EmployeeTask.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Data.Implementations
{

    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext _context) : base(_context)
        {
        }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }

}
