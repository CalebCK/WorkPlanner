using CurrencyConvertor.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkPlanner.Constants;
using WorkPlanner.Extensions.Exceptions;
using WorkPlanner.Models.Data;
using WorkPlanner.V1.DataTransferObjects;
using WorkPlanner.V1.Services.IServices;
using WorkPlanner.V1.TestableHelpers;

namespace WorkPlanner.V1.Services
{
    public partial class RegularShiftService : IShiftService
    {
        private ShiftServiceHelper _serviceHelper;
        public RegularShiftService()
        {
            _serviceHelper = new ShiftServiceHelper();
        }

        public List<ShiftPlanResponseDto> ProcessRequest(ShiftRequestDto request)
        {
            var responseDto = new List<ShiftPlanResponseDto>();

            var workersRaw = _serviceHelper.GetWorkers(request.WorkerNames);
            var workers = workersRaw.GetEnumerator();
            var availableWorkingDays = _serviceHelper.CreateWorkDays(request.NumberOfDays);

            foreach (var day in availableWorkingDays)
            {
                var dayShifts = new List<DayShiftDto>();

                foreach (var (shift, index) in day.Shifts.WithIndex())
                {
                    SetAvailableWorkerInDay(dayShifts, ref workers);

                    var workerShift = new DayShiftDto()
                    {
                        WorkerId = workers.Current.Id,
                        WorkerName = workers.Current.Name,
                        StartTime = shift.StartTime.ToString("h:mm tt"),
                        EndTime = shift.EndTime.ToString("h:mm tt")
                    };

                    dayShifts.Add(workerShift);
                }

                responseDto.Add(new() { Date = day.ShiftDate.ToString("dddd, dd MMMM yyyy"), Shifts = dayShifts });
            }

            return responseDto;
        }
    }
}
