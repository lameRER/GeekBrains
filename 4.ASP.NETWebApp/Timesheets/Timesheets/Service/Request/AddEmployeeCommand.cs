using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Service.Responses;

namespace Timesheets.Service.Request
{
    public class AddEmployeeCommand : IRequest<EmployeeDto>
    {
        public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeDto>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<EmployeeDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.Create(_mapper.Map<Employee>(request));
                return _mapper.Map<EmployeeDto>(employee);
            }
        }
    }
}