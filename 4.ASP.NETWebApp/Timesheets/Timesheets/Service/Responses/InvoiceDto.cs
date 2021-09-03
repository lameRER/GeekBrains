using System;

namespace Timesheets.Service.Responses
{
    public class InvoiceDto
    {
        public int ContractId { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public string Description { get; set; }
    }
}