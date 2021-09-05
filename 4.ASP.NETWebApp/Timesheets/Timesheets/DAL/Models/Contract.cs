using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        public string Number { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime SetDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public Customer Customer { get; set; }
        
        public ICollection<Invoice> Invoices { get; set; }
    }
}