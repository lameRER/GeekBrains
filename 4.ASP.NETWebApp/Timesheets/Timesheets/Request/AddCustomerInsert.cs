using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class AddCustomerInsert : IRequest<CustomerDto>
    {
        [FromBody]
        public string Name { get; set; }

        public class AddCustomerInsertHandler : IRequestHandler<AddCustomerInsert, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public AddCustomerInsertHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(AddCustomerInsert query, CancellationToken cancellationToken)
            {
                var customer = await _repository.Create(_mapper.Map<Customer>(query));
                return _mapper.Map<CustomerDto>(customer);
            }
        }
    }
}