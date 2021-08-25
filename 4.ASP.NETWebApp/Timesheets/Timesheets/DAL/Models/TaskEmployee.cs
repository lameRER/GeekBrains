namespace Timesheets.DAL.Models
{
    public class TaskEmployee
    {
        public int Id { get; set; }
        
        public int TaskId { get; set; }
        
        public int EmployeeId { get; set; }
        
        public int TimeSpent { get; set; }
        
        public virtual Task Task { get; set; }
        
        public virtual Employee Employee { get; set; }
    }
}