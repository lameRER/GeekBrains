using System;
using System.Collections.Generic;
using Timesheets.DAL.Models;

namespace Timesheets.Domain
{
    public class InvoiceAgregate : Invoice
    {
        private InvoiceAgregate(){}

        public static InvoiceAgregate Create(int contractId, DateTime date,  string description)
        {
            var agregate = new InvoiceAgregate
            {
                ContractId = contractId,
                Date = date,
                Description = description
            };
            return agregate;
        }

        public void IncludeSheets(IEnumerable<Task> tasks)
        {
            Tasks = new List<Task>();
            foreach (var task in tasks)
            {
                if (task.InvoiceId is not null)
                    throw new AggregateException($"Для заданного идентификатора задачи = {task.Id} Счет уже сформирован.");
                Tasks.Add(task);
            }
        }
    }
}