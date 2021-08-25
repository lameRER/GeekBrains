using System;
using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public sealed class Invoice
    {
        public Invoice()
        {
            Tasks = new HashSet<Task>();
        }
        
        public int Id { get; set; }
        
        public int ContractId { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public string Description { get; set; }
        
        public Contract Contract { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
    }
}
