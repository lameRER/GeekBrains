using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Responses;
using Task = Timesheets.DAL.Models.Task;

namespace Timesheets.Request
{
    public class AddInvoiceCommand : IRequest<InvoiceDto>
    {
        [FromRoute]
        public int ContractId { get; set; }
        
        [FromBody]
        public DateTime Date { get; set; }
        
        [FromBody]
        public decimal Total { get; set; }
        
        [FromBody]
        public string Decription { get; set; }
        
        [FromBody]
        public ICollection<Task> Tasks { get; set; }

        public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, InvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IContractRepository _contractRepository;
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper, IContractRepository contractRepository, ITaskRepository taskRepository)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
                _contractRepository = contractRepository;
                _taskRepository = taskRepository;
            }

            public async Task<InvoiceDto> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
            {
                var contract = await _contractRepository.GetById(request.ContractId);
                if (contract == null) return null;
                var invoice = _mapper.Map<Invoice>(request);
                invoice.Contract = contract;
                foreach (var taskItem in request.Tasks)
                {
                    var task = await _taskRepository.GetById(taskItem.Id);
                    invoice.Tasks.Add(task);
                }

                invoice = await _invoiceRepository.Create(invoice);
                await _contractRepository.AddInvoice(invoice);
                return _mapper.Map<InvoiceDto>(invoice);
            }
        }
    }
}