using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class AddCustomerQuery : IRequest<CustomerDto>
    {
        public string Name { get; set; }
        
        public class AddCustomerQueryHander : IRequestHandler<AddCustomerQuery, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public AddCustomerQueryHander(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(AddCustomerQuery query, CancellationToken cancellationToken)
            {
                var customer = await _repository.Create(_mapper.Map<Customer>(query));
                return _mapper.Map<CustomerDto>(customer);
            }
        }
    }
}