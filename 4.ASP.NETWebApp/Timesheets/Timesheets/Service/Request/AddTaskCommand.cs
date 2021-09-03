using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.Service.Responses;
using Task = Timesheets.DAL.Models.Task;

namespace Timesheets.Service.Request
{
    public class AddTaskCommand : IRequest<TaskDto>
    {
        public string Name { get; set;}
        
        public int Amount { get; set;}
        
        public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, TaskDto>
        {
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public AddTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
            {
                _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<TaskDto> Handle(AddTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.Create(_mapper.Map<Task>(request));
                return _mapper.Map<TaskDto>(task);
            }
        }
    }
}