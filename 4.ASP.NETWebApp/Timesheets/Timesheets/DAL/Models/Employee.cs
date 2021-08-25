using System.Collections.Generic;

namespace Timesheets.DAL.Models
{
    public sealed class Employee
    {
        public Employee()
        {
            TaskEmployee = new HashSet<TaskEmployee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Rate { get; set; }
        
        public ICollection<TaskEmployee> TaskEmployee { get; set; }
    }
}