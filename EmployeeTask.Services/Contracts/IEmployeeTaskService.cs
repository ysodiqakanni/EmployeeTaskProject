using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Services.Contracts
{
    public interface IEmployeeTaskService
    {
        DomainModels.EmployeeTask CreateNewTask(DomainModels.EmployeeTask task);
        List<DomainModels.EmployeeTask> GetAll();
        DomainModels.EmployeeTask GetEmployeeTaskById(int id);
        Task<DomainModels.EmployeeTask> UpdateEmployeeTask(DomainModels.EmployeeTask task);
        void DeleteEmployeeTask(DomainModels.EmployeeTask task);
    }
}
