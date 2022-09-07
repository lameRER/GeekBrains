using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Models;

namespace Timesheets.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> Get();

        Task<Employee> GetById(int id);

        Task<ICollection<TaskEmployee>> GetTaskEmployees(int employeeId);

        Task<Employee> Create(Employee employee);
    }
}