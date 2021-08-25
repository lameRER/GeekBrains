using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> Get();

        Task<Customer> GetById(int id);

        Task<Customer> Create(Customer customer);

        Task AddContract(Contract contract);
    }
}