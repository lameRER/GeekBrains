using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public class Contract
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
        
        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}