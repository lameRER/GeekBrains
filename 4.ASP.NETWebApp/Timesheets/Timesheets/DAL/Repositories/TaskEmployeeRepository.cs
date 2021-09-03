using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.EF;
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
            _baseContext = baseContext ?? throw new ArgumentNullException(nameof(baseContext));
        }

        public async Task<ICollection<TaskEmployee>> GetEmployeeTaskExecutions(Employee employee)
        {
            return await Task.Run<ICollection<TaskEmployee>>(() => _baseContext.TaskEmployee.Where(i => i.Employee == employee).ToList());
        }

        public async Task<TaskEmployee> Create(TaskEmployee taskEmployee)
        {
            try
            {
                await _baseContext.TaskEmployee.AddAsync(taskEmployee);
                await _baseContext.SaveChangesAsync();
                return taskEmployee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}