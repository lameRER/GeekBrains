using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly DataBaseContext _baseContext;

        public ContractRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<ICollection<Contract>> GetByCustomer(Customer customer)
        {
            return await Task.Run<ICollection<Contract>>(() => _baseContext.Contracts.Where(i => i.Customer == customer).ToList());
        }

        public async Task<Contract> GetById(int id)
        {
            return await Task.Run((() => _baseContext.Contracts.SingleOrDefault(i => i.Id == id)));
        }

        public async Task<Contract> Create(Contract contract)
        {
            return await Task.Run(() =>
            {
                var maxId = (_baseContext.Contracts.Any(i => i.Id != 0)) ? _baseContext.Contracts.Max(i => i.Id) : 0;
                contract.Id = maxId + 1;
                _baseContext.Contracts.Add(contract);
                return contract;
            });
        }

        public async Task AddInvoice(Invoice invoice)
        {
            await Task.Run(() =>
            {
                var contract = _baseContext.Contracts.FirstOrDefault(i => i.Id == invoice.Contract.Id);
                contract?.Invoices.Add(invoice);
            });
        }
    }
}