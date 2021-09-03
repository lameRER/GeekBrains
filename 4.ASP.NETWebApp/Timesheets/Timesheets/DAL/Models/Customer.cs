using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.DAL.Models
{
    public sealed class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
        }
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<Contract> Contracts { get; set; }
    }
}