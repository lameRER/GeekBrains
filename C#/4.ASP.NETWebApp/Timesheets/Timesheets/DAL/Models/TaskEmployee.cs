using System.ComponentModel.DataAnnotations;

namespace Timesheets.DAL.Models
{
    public class TaskEmployee
    {
        public int Id { get; set; }
        
        [Required]
        public int TaskId { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public int TimeSpent { get; set; }
        
        public virtual Task Task { get; set; }
        
        public virtual Employee Employee { get; set; }
    }
}