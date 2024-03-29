using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.Service.Responses;

namespace Timesheets.Service.Request
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
                _contractRepository = contractRepository ?? throw new ArgumentNullException(nameof(contractRepository));
                _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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