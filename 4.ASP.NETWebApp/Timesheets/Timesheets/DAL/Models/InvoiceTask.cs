namespace Timesheets.DAL.Models
{
    public class InvoiceTask
    {
        public int Id { get; set; }
        
        public int InvoiceId { get; set; }
        
        public int TaskId { get; set; }
        
        public virtual Invoice Invoice { get; set; }
        
        public virtual Task Task { get; set; }
    }
}