using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.DAL.EF;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataBaseContext _baseContext;

        public EmployeeRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext ?? throw new ArgumentNullException(nameof(baseContext));
        }

        public async Task<ICollection<Employee>> Get()
        {
            return await Task.Run(() => _baseContext.Employees.ToListAsync()).ConfigureAwait(false);
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
            try
            {
                await _baseContext.Employees.AddAsync(employee);
                await _baseContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}