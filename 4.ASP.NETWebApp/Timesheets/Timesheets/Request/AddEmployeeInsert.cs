using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Models;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class AddEmployeeInsert : IRequest<EmployeeDto>
    {
        public class AddEmployeeInsertHandler : IRequestHandler<AddEmployeeInsert, EmployeeDto>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public AddEmployeeInsertHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }

            public async Task<EmployeeDto> Handle(AddEmployeeInsert request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.Create(_mapper.Map<Employee>(request));
                return _mapper.Map<EmployeeDto>(employee);
            }
        }
    }
}