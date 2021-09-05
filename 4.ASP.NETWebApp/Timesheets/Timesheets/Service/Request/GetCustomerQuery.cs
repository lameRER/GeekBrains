using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.Service.Responses;

namespace Timesheets.Service.Request
{
    public class GetCustomerQuery : IRequest<TimesheetResponse<CustomerDto>>
    {
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery ,TimesheetResponse<CustomerDto>>
        {
            private readonly ICustomerRepository _repository;

            private readonly IMapper _mapper;

            public GetCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<TimesheetResponse<CustomerDto>> Handle(GetCustomerQuery query,
                CancellationToken cancellationToken)
            {
                var customers = await _repository.Get();
                var response = new TimesheetResponse<CustomerDto>();
                response.Timesheet.AddRange(_mapper.Map<List<CustomerDto>>(customers));
                return response;
            }
        }
    }
}