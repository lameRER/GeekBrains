using System.Collections.Generic;

namespace Timesheets.DAL.Model
{
    public class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}