using System;

namespace Timesheets.DAL.Model
{
    public class Contract
    {
        public int Id { get; set;}
        public int ClientId { get; set;}
        public string Number { get; set;}
        public DateTime Date { get; set;}
        public string Name { get; set;}
    }
}