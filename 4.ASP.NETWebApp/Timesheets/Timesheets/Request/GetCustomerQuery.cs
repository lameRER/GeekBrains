using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class GetCustomerQuery : IRequest<TimesheetResponse<CustomerDto>>
    {
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery ,TimesheetResponse<CustomerDto>>
        {
            private readonly ICustomerRepository _repository;

            private readonly IMapper _mapper;

            public GetCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
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