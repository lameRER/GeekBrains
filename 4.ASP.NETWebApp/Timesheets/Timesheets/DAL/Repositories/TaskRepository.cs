using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return await Task.Run<ICollection<Models.Task>>(() => _baseContext.Tasks);
        }

        public async Task<Models.Task> GetById(int id)
        {
            return await Task.Run((() => _baseContext.Tasks.SingleOrDefault(i => i.Id == id)));
        }

        public async Task<Models.Task> Create(Models.Task task)
        {
            return await Task.Run((() =>
            {
                var maxId = (_baseContext.Tasks.Any(item => item.Id != 0)) ? _baseContext.Tasks.Max(item => item.Id) : 0;
                task.Id = maxId + 1;
                _baseContext.Tasks.Add(task);
                return task;
            }));
        }
    }
}