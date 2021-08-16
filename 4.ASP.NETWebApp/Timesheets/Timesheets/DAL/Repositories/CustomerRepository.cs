using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = Timesheets.DAL.Models.Task;

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
            var result = await System.Threading.Tasks.Task.Run<ICollection<Customer>>
            (() => _baseContext.Customers);
            return result;
        }

        public Task<Customer> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> Create(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task AddContract(Contract entity)
        {
            throw new System.NotImplementedException();
        }
    }
}