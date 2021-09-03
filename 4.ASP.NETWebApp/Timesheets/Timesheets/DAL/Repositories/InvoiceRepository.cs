using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DAL.EF;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace Timesheets.DAL.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataBaseContext _baseContext;

        public InvoiceRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext ?? throw new ArgumentNullException(nameof(baseContext));
        }

        public async Task<ICollection<Invoice>> GetContractInvoiceByPeriod(Contract contract, DateTime dateFrom, DateTime dateTo)
        {
            return await Task.Run<ICollection<Invoice>>(() => _baseContext.Invoices.Where(i => i.Contract == contract && i.Date == dateFrom && i.Date < dateTo).ToList());
        }

        public async Task<Invoice> Create(Invoice invoice)
        {
            try
            {
                await _baseContext.Invoices.AddAsync(invoice);
                await _baseContext.SaveChangesAsync();
                return invoice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}