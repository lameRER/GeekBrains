using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataBaseContext _baseContext;

        public CustomerRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public async Task<ICollection<Customer>> Get()
        {
            var result = await Task.Run<ICollection<Customer>>
            (() => _baseContext.Customers);
            return result;
        }

        public async Task<Customer> GetById(int id)
        {
            var result = await Task.Run(() =>
            {
                return _baseContext.Customers.SingleOrDefault(i => i.Id == id);
            });
            return result;
        }

        public async Task<Customer> Create(Customer customer)
        {
            await Task.Run(() =>
            {
                var maxId = (_baseContext.Customers.Any(item => item.Id != 0)) ? _baseContext.Customers.Max(item => item.Id) : 0;
                customer.Id = maxId + 1;
                _baseContext.Customers.Add(customer);
                return customer;
            });

            return customer;
        }

        public async Task AddContract(Contract contract)
        {
            await Task.Run(() =>
            {
                var customer = _baseContext.Customers.FirstOrDefault(i => i.Id == contract.Customer.Id);
                customer?.Contracts.Add(contract);
            });
        }
    }
}