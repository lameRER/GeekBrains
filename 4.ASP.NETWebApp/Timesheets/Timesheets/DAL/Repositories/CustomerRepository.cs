using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await Task.Run(() => _baseContext.Customers.ToListAsync()).ConfigureAwait(false);
        }

        public async Task<Customer> GetById(int id)
        {
            return await Task.Run(() => _baseContext.Customers.SingleOrDefault(i => i.Id == id));
        }

        public async Task<Customer> Create(Customer customer)
        {
            try
            {
                await _baseContext.Customers.AddAsync(customer);
                await _baseContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
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