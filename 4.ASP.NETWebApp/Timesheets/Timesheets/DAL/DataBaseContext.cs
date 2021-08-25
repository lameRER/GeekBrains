using System.Collections.Generic;
using Timesheets.DAL.Models;

namespace Timesheets.DAL
{
    public class DataBaseContext
    {
        public IList<Contract> Contracts { get; set; } = new List<Contract>();

        public IList<Customer> Customers { get; set; } = new List<Customer>();

        public IList<Employee> Employees { get; set; } = new List<Employee>();

        public IList<Task> Tasks { get; set; } = new List<Task>();

        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();

        public IList<TaskEmployee> TaskEmployee { get; set; } = new List<TaskEmployee>();
    }
}