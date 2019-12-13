using EmployeeTask.Data.Contracts;
using EmployeeTask.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Services.Implementations
{ 
    public class EmployeeTaskService : IEmployeeTaskService
    {

        IUnitOfWork uow;
        IEmployeeService empSvc;
        public EmployeeTaskService(IUnitOfWork _uow, IEmployeeService _empSvc)
        {
            uow = _uow;
            empSvc = _empSvc;
        }

        public DomainModels.EmployeeTask CreateNewTask(DomainModels.EmployeeTask task)
        {
            if (task == null)
                throw new Exception("Task cannot be null");
            var employee = empSvc.GetEmployeeById(task.EmployeeId);
            if (employee == null)
                throw new Exception("Employee not found!");

            uow.EmployeeTaskRepository.Add(task);
            uow.Complete();
            return task;
        }
        public List<DomainModels.EmployeeTask> GetAll()
        {
            var tasks = uow.EmployeeTaskRepository.GetAll().ToList();
            return tasks;
        }
        public DomainModels.EmployeeTask GetEmployeeTaskById(int id)
        {
            return uow.EmployeeTaskRepository.Get(id);
        }

        public async Task<DomainModels.EmployeeTask> UpdateEmployeeTask(DomainModels.EmployeeTask task)
        {
            if (task == null)
                throw new Exception("Employee Task cannot be null");

            uow.Complete();
            return task;
        }
        public void DeleteEmployeeTask(DomainModels.EmployeeTask task)
        {
            if (task == null)
                throw new Exception("Employee Task cannot be null");
            uow.EmployeeTaskRepository.Remove(task);
            uow.Complete();
        }
    }
}
