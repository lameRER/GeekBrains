using System;

namespace Timesheets.Responses
{
    public class ContractDto
    {
        public int CustomerId { get; set; }
        
        public string Number { get; set; }
        
        public DateTime SetDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string Name { get; set; }
    }
}