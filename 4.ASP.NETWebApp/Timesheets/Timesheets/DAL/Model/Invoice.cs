using System;

namespace Timesheets.DAL.Model
{
    public class Invoice
    {
        public int ContractId { get; set;}

        public int EmployeeId { get; set;}

        public DateTime Date { get; set;}

        public decimal Total { get; set;}

        public string Description { get; set;}
    }
}