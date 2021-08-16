using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Task = Timesheets.DAL.Models.Task;

namespace Timesheets.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> Get();

        Task<Customer> GetById(int id);

        Task<Customer> Create(Customer entity);

        Task AddContract(Contract entity);
    }
}