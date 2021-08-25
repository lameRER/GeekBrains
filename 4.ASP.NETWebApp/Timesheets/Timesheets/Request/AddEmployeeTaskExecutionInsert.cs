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
    public class AddEmployeeTaskExecutionInsert : IRequest<TaskEmployeeDto>
    {
        [FromRoute]
        public int TaskId { get; set; }
        
        [FromRoute]
        public int EmployeeId { get; set; }
        
        [FromRoute]
        public int TimeSpent { get; set; }
        
        public class AddEmployeeTaskExecutionInsertHandler : IRequestHandler<AddEmployeeTaskExecutionInsert, TaskEmployeeDto>
        {
            private readonly ITaskEmployeeRepository _taskEmployeeRepository;
            private readonly IEmployeeRepository _employeeRepository;
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public AddEmployeeTaskExecutionInsertHandler(ITaskEmployeeRepository taskEmployeeRepository, IEmployeeRepository employeeRepository, ITaskRepository taskRepository, IMapper mapper)
            {
                _taskEmployeeRepository = taskEmployeeRepository;
                _employeeRepository = employeeRepository;
                _taskRepository = taskRepository;
                _mapper = mapper;
            }

            public async Task<TaskEmployeeDto> Handle(AddEmployeeTaskExecutionInsert request, CancellationToken cancellationToken)
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