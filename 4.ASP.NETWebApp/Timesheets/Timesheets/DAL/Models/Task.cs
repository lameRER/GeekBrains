using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public sealed class Task
    {
        public Task()
        {
            Invoices = new HashSet<Invoice>();
            TaskEmployee = new HashSet<TaskEmployee>();
        }
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Amount { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        
        public ICollection<TaskEmployee> TaskEmployee { get; set; }
    }
}