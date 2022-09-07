using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Interfaces
{
    public interface ITaskEmployeeRepository
    {
        Task<ICollection<TaskEmployee>> GetEmployeeTaskExecutions(Employee employee);

        Task<TaskEmployee> Create(TaskEmployee taskEmployee);
    }
}