using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Domain;
using Timesheets.Service.Responses;
using Task = Timesheets.DAL.Models.Task;

namespace Timesheets.Service.Request
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
        public ICollection<int> Tasks { get; set; }

        public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, InvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IContractRepository _contractRepository;
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper, IContractRepository contractRepository, ITaskRepository taskRepository)
            {
                _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _contractRepository = contractRepository ?? throw new ArgumentNullException(nameof(contractRepository));
                _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            }

            public async Task<InvoiceDto> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
            {
                var contract = await _contractRepository.GetById(request.ContractId);
                if (contract == null) return null;
                var invoiceAggregate = InvoiceAgregate.Create(contract.Id, request.Date, request.Decription);
                var tasks = await _taskRepository.GetByIdList(request.Tasks);
                invoiceAggregate.IncludeSheets(tasks);
                var invoice = await _invoiceRepository.Create(invoiceAggregate);
                return _mapper.Map<InvoiceDto>(invoice);
            }
        }
    }
}