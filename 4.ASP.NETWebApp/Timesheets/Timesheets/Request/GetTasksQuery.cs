using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Timesheets.DAL.Interfaces;
using Timesheets.Responses;

namespace Timesheets.Request
{
    public class GetTasksQuery : IRequest<TimesheetResponse<TaskDto>>
    {
        public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, TimesheetResponse<TaskDto>>
        {
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;

            public GetTasksQueryHandler(ITaskRepository taskRepository, IMapper mapper)
            {
                _taskRepository = taskRepository;
                _mapper = mapper;
            }

            public async Task<TimesheetResponse<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.Get();
                var response = new TimesheetResponse<TaskDto>();
                response.Timesheet.AddRange(_mapper.Map<List<TaskDto>>(task));
                return response;
            }
        }
    }
}