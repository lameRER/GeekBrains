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
    public class AddEmployeeTaskExecutionCommand : IRequest<TaskEmployeeDto>
    {
        [FromRoute]
        public int TaskId { get; set; }
        
        [FromRoute]
        public int EmployeeId { get; set; }
        
        [FromRoute]
        public int TimeSpent { get; set; }
        
        public class AddEmployeeTaskExecutionCommandHandler : IRequestHandler<AddEmployeeTaskExecutionCommand, TaskEmployeeDto>
        {
            private readonly ITaskEmployeeRepository _taskEmployeeRepository;
            private readonly IEmployeeRepository _employeeRepository;
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public AddEmployeeTaskExecutionCommandHandler(ITaskEmployeeRepository taskEmployeeRepository, IEmployeeRepository employeeRepository, ITaskRepository taskRepository, IMapper mapper)
            {
                _taskEmployeeRepository = taskEmployeeRepository ?? throw new ArgumentNullException(nameof(taskEmployeeRepository));
                _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<TaskEmployeeDto> Handle(AddEmployeeTaskExecutionCommand request, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.GetById(request.TaskId);
                var employee = await _employeeRepository.GetById(request.EmployeeId);
                if (employee == null && task == null) return null;
                var taskEmployee = _mapper.Map<TaskEmployee>(request);
                taskEmployee = await _taskEmployeeRepository.Create(taskEmployee);
                employee?.TaskEmployee.Add(taskEmployee);
                task.TaskEmployee.Add(taskEmployee);
                return _mapper.Map<TaskEmployeeDto>(taskEmployee);
            }
        }
    }
}