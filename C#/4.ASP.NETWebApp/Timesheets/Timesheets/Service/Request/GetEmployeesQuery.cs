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
    public class GetEmployeesQuery : IRequest<TimesheetResponse<EmployeeDto>>
    {
        public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, TimesheetResponse<EmployeeDto>>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<TimesheetResponse<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
            {
                var employees = await _employeeRepository.Get();
                var response = new TimesheetResponse<EmployeeDto>();
                response.Timesheet.AddRange(_mapper.Map<List<EmployeeDto>>(employees));
                return response;
            }
        }
    }
}