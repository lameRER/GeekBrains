using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public sealed class Contract
    {
        public Contract()
        {
            Invoices = new HashSet<Invoice>();
        }
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        
        public string Number { get; set; }
        
        public DateTime SetDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string Name { get; set; }
        
        public Customer Customer { get; set; }
        
        public ICollection<Invoice> Invoices { get; set; }
    }
}