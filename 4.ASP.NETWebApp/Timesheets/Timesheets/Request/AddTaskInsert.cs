using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.Responses;
using Task = Timesheets.DAL.Models.Task;

namespace Timesheets.Request
{
    public class AddTaskInsert : IRequest<TaskDto>
    {
        public string Name { get; set;}
        public int Amount { get; set;}
        
        public class AddTaskInsertHandler : IRequestHandler<AddTaskInsert, TaskDto>
        {
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public AddTaskInsertHandler(ITaskRepository taskRepository, IMapper mapper)
            {
                _taskRepository = taskRepository;
                _mapper = mapper;
            }

            public async Task<TaskDto> Handle(AddTaskInsert request, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.Create(_mapper.Map<Task>(request));
                return _mapper.Map<TaskDto>(task);
            }
        }
    }
}