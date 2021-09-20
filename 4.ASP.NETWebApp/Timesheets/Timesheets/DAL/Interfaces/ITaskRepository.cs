using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.DAL.Interfaces
{
    public interface ITaskRepository
    {
        Task<ICollection<Models.Task>> Get();

        Task<Models.Task> GetById(int id);

        Task<Models.Task> Create(Models.Task task);

        Task<ICollection<Models.Task>> GetByIdList(ICollection<int> list);
    }
}