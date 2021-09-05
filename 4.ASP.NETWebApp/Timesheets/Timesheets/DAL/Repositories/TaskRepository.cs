using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataBaseContext _baseContext;

        public TaskRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<ICollection<Models.Task>> Get()
        {
            return await Task.Run(() => _baseContext.Tasks.ToListAsync()).ConfigureAwait(false);
        }

        public async Task<Models.Task> GetById(int id)
        {
            return await Task.Run((() => _baseContext.Tasks.SingleOrDefault(i => i.Id == id)));
        }

        public async Task<Models.Task> Create(Models.Task task)
        {
            try
            {
                await _baseContext.Tasks.AddAsync(task);
                await _baseContext.SaveChangesAsync();
                return task;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}