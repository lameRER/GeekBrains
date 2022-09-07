using System.Collections.Generic;

namespace Timesheets.Service.Responses
{
    public class TimesheetResponse<T>
    {
        public List<T> Timesheet { get; set; } = new();
    }
}