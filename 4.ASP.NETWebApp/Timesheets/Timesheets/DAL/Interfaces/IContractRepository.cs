using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Interfaces
{
    public interface IContractRepository
    {
        Task<ICollection<Contract>> GetByCustomer(Customer customer);
        
        Task<Contract> GetById(int id);
        
        Task<Contract> Create(Contract contract);

        Task AddInvoice(Invoice invoice);
    }
}