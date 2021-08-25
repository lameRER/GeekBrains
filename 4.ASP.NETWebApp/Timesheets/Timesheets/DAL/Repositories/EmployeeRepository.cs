using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DataBaseContext _baseContext;

        public EmployeeRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<ICollection<Employee>> Get()
        {
            return await Task.Run<ICollection<Employee>>(() => _baseContext.Employees);
        }

        public async Task<Employee> GetById(int id)
        {
            return await Task.Run(() => _baseContext.Employees.SingleOrDefault(i => i.Id == id));
        }

        public async Task<ICollection<TaskEmployee>> GetTaskEmployees(int employeeId)
        {
            return await Task.Run(() =>
            {
                var employee = _baseContext.Employees.SingleOrDefault(i => i.Id == employeeId);
                return employee?.TaskEmployee;
            });
        }

        public async Task<Employee> Create(Employee employee)
        {
            return await Task.Run((() =>
            {
                var maxId = (_baseContext.Employees.Any(item => item.Id != 0)) ? _baseContext.Employees.Max(item => item.Id) : 0;
                employee.Id = maxId + 1;
                return employee;
            })); 
        }
    }
}