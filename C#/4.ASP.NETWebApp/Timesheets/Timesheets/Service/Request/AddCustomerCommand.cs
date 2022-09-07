using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Service.Responses;

namespace Timesheets.Service.Request
{
    public class AddCustomerCommand : IRequest<CustomerDto>
    {
        [FromBody]
        public string Name { get; set; }

        public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public AddCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CustomerDto> Handle(AddCustomerCommand query, CancellationToken cancellationToken)
            {
                var customer = await _repository.Create(_mapper.Map<Customer>(query));
                return _mapper.Map<CustomerDto>(customer);
            }
        }
    }
}