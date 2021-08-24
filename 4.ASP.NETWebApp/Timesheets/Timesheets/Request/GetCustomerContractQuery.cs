using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class GetCustomerContractQuery : IRequest<TimesheetResponse<ContractDto>>
    {
        [FromRoute]
        public int CustomerId { get; set; }
        
        public class GetCustomerContractQueryHandler : IRequestHandler<GetCustomerContractQuery, TimesheetResponse<ContractDto>>
        {
            private readonly IContractRepository _contractRepository;
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetCustomerContractQueryHandler(IContractRepository contractRepository, ICustomerRepository customerRepository, IMapper mapper)
            {
                _contractRepository = contractRepository;
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<TimesheetResponse<ContractDto>> Handle(GetCustomerContractQuery query, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetById(query.CustomerId);
                if (customer == null) return null;
                var contract = await _contractRepository.GetByCustomer(customer);
                var response = new TimesheetResponse<ContractDto>();
                response.Timesheet.AddRange(_mapper.Map<List<ContractDto>>(contract));
                return response;
            }
        }
    }
}