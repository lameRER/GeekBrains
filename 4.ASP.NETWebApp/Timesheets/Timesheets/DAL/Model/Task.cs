using System.Collections.Generic;

namespace Timesheets.DAL.Model
{
    public class Task
    {
        public Task()
        {
            InvoiceTasks = new HashSet<InvoiceTask>();
            TaskExecutions = new HashSet<TaskEmployee>();
        }
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Amount { get; set; }

        public virtual ICollection<InvoiceTask> InvoiceTasks { get; set; }
        
        public virtual ICollection<TaskEmployee> TaskExecutions { get; set; }
    }
}