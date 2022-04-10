using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkPlanner.V1.DataTransferObjects
{
    public class ShiftRequestDto : IValidatableObject
    {
        public string[] WorkerNames { get; set; }
        public int NumberOfDays { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (WorkerNames.Length < 3)
            {
                yield return new ValidationResult("Provide a minimum of 3 worker names", new string[] { "Employees" });
            }
            if (NumberOfDays < 1)
            {
                yield return new ValidationResult("Provide a minimum of 1 day for shift planning", new string[] { "NumberOfDays" });
            }
        }
    }

    public class ShiftPlanResponseDto
    {
        public string Date { get; set; }
        public List<DayShiftDto> Shifts { get; set; }
    }

    public class DayShiftDto
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
