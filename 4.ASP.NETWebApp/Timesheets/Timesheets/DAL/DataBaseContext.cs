using Microsoft.EntityFrameworkCore;
using Timesheets.DAL.Models;

namespace Timesheets.DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<TaskEmployee> TaskEmployee { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }
    }
}