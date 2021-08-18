using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class GetCustomerByIdQuery : IRequest<TimesheetResponse<CustomerDto>>
    {
        private static int _id;
        
        public GetCustomerByIdQuery(int id)
        {
            _id = id;
        }
        
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery ,TimesheetResponse<CustomerDto>>
        {
            private readonly ICustomerRepository _repository;

            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<TimesheetResponse<CustomerDto>> Handle(GetCustomerByIdQuery query,
                CancellationToken cancellationToken)
            {
                var customers = await _repository.GetById(_id);
                var response = new TimesheetResponse<CustomerDto>();
                response.Timesheet.Add(_mapper.Map<CustomerDto>(customers));
                return response;
            }
        }
    }
}