using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                await _baseContext.Contracts.AddAsync(contract);
                await _baseContext.SaveChangesAsync();
                return contract;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
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