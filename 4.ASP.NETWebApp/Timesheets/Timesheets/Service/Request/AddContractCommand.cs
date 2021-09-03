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
    public class AddContractCommand : IRequest<CustomerDto>
    {
        [FromBody]
        public string Name { get; set; }
        
        [FromRoute]
        public int CustomerId { get; set; }
        
        [FromBody]
        public string Number { get; set; }
        
        [FromBody]
        public DateTime SetDate { get; set; }
        
        [FromBody]
        public DateTime EndDate { get; set; }
        
        public class AddContractCommandHandler : IRequestHandler<AddContractCommand, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IContractRepository _contractRepository;
            private readonly IMapper _mapper;

            public AddContractCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IContractRepository contractRepository)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _contractRepository = contractRepository;
            }

            public async Task<CustomerDto> Handle(AddContractCommand request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetById(request.CustomerId);
                if (customer == null) return null;
                var contract = _mapper.Map<Contract>(request);
                contract.Customer = customer;
                contract = await _contractRepository.Create(contract);
                await _customerRepository.AddContract(contract);
                return _mapper.Map<CustomerDto>(customer);
            }
        }
    }
}