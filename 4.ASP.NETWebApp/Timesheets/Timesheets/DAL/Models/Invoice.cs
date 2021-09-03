using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.DAL.Models
{
    public sealed class Invoice
    {
        public Invoice()
        {
            Tasks = new HashSet<Task>();
        }
        
        public int Id { get; set; }
        
        [Required]
        public int ContractId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Total { get; set; }

        public string Description { get; set; }
        
        public Contract Contract { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
    }
}
