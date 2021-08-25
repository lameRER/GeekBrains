using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class GetContractInvoicesByIdQuery : IRequest<TimesheetResponse<InvoiceDto>>
    {
        public int ContractId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        public class GetContractInvoicesByIdQueryHandler : IRequestHandler<GetContractInvoicesByIdQuery, TimesheetResponse<InvoiceDto>>
        {
            private readonly IInvoiceRepository _invoceRepository;
            private readonly IContractRepository _contractRepository;
            private readonly IMapper _mapper;

            public GetContractInvoicesByIdQueryHandler(IInvoiceRepository invoceRepository, IContractRepository contractRepository, IMapper mapper)
            {
                _invoceRepository = invoceRepository;
                _contractRepository = contractRepository;
                _mapper = mapper;
            }

            public async Task<TimesheetResponse<InvoiceDto>> Handle(GetContractInvoicesByIdQuery query,
                CancellationToken cancellationToken)
            {
                var contract = await _contractRepository.GetById(query.ContractId);
                if (contract == null) return null;
                var invoice =
                    await _invoceRepository.GetContractInvoiceByPeriod(contract, query.DateFrom, query.DateTo);
                var response = new TimesheetResponse<InvoiceDto>();
                response.Timesheet.AddRange(_mapper.Map<List<InvoiceDto>>(invoice));
                return response;
            }
        }
    }
}