using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.Service.Responses;

namespace Timesheets.Service.Request
{
    public class GetCustomerByIdQuery : IRequest<TimesheetResponse<CustomerDto>>
    {
        [FromRoute]
        public int Id { get; set; }
        
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery ,TimesheetResponse<CustomerDto>>
        {
            private readonly ICustomerRepository _customerRepository;

            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<TimesheetResponse<CustomerDto>> Handle(GetCustomerByIdQuery query,
                CancellationToken cancellationToken)
            {
                var customers = await _customerRepository.GetById(query.Id);
                var response = new TimesheetResponse<CustomerDto>();
                response.Timesheet.Add(_mapper.Map<CustomerDto>(customers));
                return response;
            }
        }
    }
}