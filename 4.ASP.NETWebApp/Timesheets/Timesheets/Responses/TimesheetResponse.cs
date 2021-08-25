using System.Collections.Generic;

namespace Timesheets.Responses
{
    public class TimesheetResponse<T>
    {
        public List<T> Timesheet { get; set; } = new();
    }
}