using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceTasksCollection = new HashSet<InvoiceTask>();
        }
        
        public int Id { get; set; }
        
        public int ContractId { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public string Description { get; set; }
        
        public virtual Contract Contract { get; set; }
        
        public virtual ICollection<InvoiceTask> InvoiceTasksCollection { get; set; }
    }
}
