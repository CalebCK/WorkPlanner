using System;
using System.Collections.Generic;
using WorkPlanner.Constants;

namespace WorkPlanner.Models.Data
{
    public class WorkDay
    {
        public DateTime ShiftDate { get; set; }
        public IList<DayShift> Shifts { get; set; }
    }

    /// <summary>
    /// End time for shift is automatically start time plus defined shift duration constant
    /// </summary>
    public class DayShift
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get { return StartTime.AddHours(ShiftConstants.ShiftHours); } }
    }
}
