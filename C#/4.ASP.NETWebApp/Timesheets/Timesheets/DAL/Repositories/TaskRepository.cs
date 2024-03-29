using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.DAL.EF;
using Timesheets.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataBaseContext _baseContext;

        public TaskRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext ?? throw new ArgumentNullException(nameof(baseContext));
        }

        public async Task<ICollection<Models.Task>> Get()
        {
            return await Task.Run(() => _baseContext.Tasks.ToListAsync()).ConfigureAwait(false);
        }

        public async Task<Models.Task> GetById(int id)
        {
            return await Task.Run(() => _baseContext.Tasks.SingleOrDefault(i => i.Id == id)).ConfigureAwait(false);
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

        public async Task<ICollection<Models.Task>> GetByIdList(ICollection<int> list)
        {
            return await _baseContext.Tasks.Where(t => list.Contains(t.Id)).Include(i => i.Invoice).ToListAsync().ConfigureAwait(false);
        }
    }
}