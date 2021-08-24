using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class TaskEmployeeRepository : ITaskEmployeeRepository
    {
        private readonly DataBaseContext _baseContext;

        public TaskEmployeeRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<ICollection<TaskEmployee>> GetEmployeeTaskExecutions(Employee employee)
        {
            return await Task.Run<ICollection<TaskEmployee>>(() => _baseContext.TaskEmployee.Where(i => i.Employee == employee).ToList());
        }

        public async Task<TaskEmployee> Create(TaskEmployee taskEmployee)
        {
            return await Task.Run(() =>
            {
                var maxId = (_baseContext.TaskEmployee.Any(item => item.Id != 0))
                    ? _baseContext.TaskEmployee.Max(item => item.Id)
                    : 0;
                taskEmployee.Id = maxId + 1;
                _baseContext.TaskEmployee.Add(taskEmployee);
                return taskEmployee;
            });
        }
    }
}