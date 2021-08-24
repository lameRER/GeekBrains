using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _baseContext = baseContext;
        }

        public async Task<ICollection<Invoice>> GetContractInvoiceByPeriod(Contract contract, DateTime dateFrom, DateTime dateTo)
        {
            return await Task.Run<ICollection<Invoice>>(() => _baseContext.Invoices.Where(i => i.Contract == contract && i.Date == dateFrom && i.Date < dateTo).ToList());
        }

        public async Task<Invoice> Create(Invoice invoice)
        {
            return await Task.Run(() =>
            {
                var maxId = (_baseContext.Invoices.Any(item => item.Id != 0)) ? _baseContext.Invoices.Max(item => item.Id) : 0;
                invoice.Id = maxId + 1;
                _baseContext.Invoices.Add(invoice);
                return invoice;
            });
        }
    }
}