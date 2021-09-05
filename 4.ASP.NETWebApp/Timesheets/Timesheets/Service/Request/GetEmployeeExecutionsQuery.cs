using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.Service.Responses;

namespace Timesheets.Service.Request
{
    public class GetEmployeeExecutionsQuery : IRequest<TimesheetResponse<TaskEmployeeDto>>
    {
        [FromRoute]
        public int EmployeeId { get; set; }
        
        public class GetEmployeeExecutionsQueryHandler : IRequestHandler<GetEmployeeExecutionsQuery, TimesheetResponse<TaskEmployeeDto>>
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;

            public GetEmployeeExecutionsQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<TimesheetResponse<TaskEmployeeDto>> Handle(GetEmployeeExecutionsQuery request, CancellationToken cancellationToken)
            {
                var taskEmployees = await _employeeRepository.GetTaskEmployees(request.EmployeeId);
                var response = new TimesheetResponse<TaskEmployeeDto>();
                response.Timesheet.AddRange(_mapper.Map<List<TaskEmployeeDto>>(taskEmployees));
                return response;
            }
        }
    }
}