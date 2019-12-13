using EmployeeTask.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTask.Data.Implementations
{
    public class EmployeeTaskRepository : Repository<DomainModels.EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(AppDbContext _context) : base(_context)
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
