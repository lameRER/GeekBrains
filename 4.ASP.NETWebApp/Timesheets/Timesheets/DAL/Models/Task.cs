using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.DAL.Models
{
    public sealed class Task
    {
        public Task()
        {
            TaskEmployee = new HashSet<TaskEmployee>();
        }
        
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public int Amount { get; set; }
        
        [Required]
        public int InvoiceId { get; set; }
        
        public bool IsCompleted { get; set; }

        public Invoice Invoice { get; set; }
        public ICollection<TaskEmployee> TaskEmployee { get; set; }
    }
}