using System;
using System.Collections.Generic;
using System.Linq;
using WorkPlanner.Constants;
using WorkPlanner.Extensions.Exceptions;
using WorkPlanner.Models.Data;
using WorkPlanner.V1.DataTransferObjects;
using WorkPlanner.V1.Services.IServices;

namespace WorkPlanner.V1.Services
{
    public partial class RegularShiftService : IShiftService
    {
        /// <summary>
        /// Algo to make select next available worker for a shift
        /// </summary>
        /// <param name="dayShifts"></param>
        /// <param name="workers"></param>
        private void SetAvailableWorkerInDay(List<DayShiftDto> dayShifts, ref IEnumerator<Worker> workers)
        {
            NextWorker(ref workers);

            var availableWorker = workers.Current;

            if (dayShifts.Any(x => x.WorkerId == availableWorker.Id))
            {
                NextWorker(ref workers);
            }
        }

        private void NextWorker(ref IEnumerator<Worker> workers)
        {
            var isMoved = workers.MoveNext();

            if (!isMoved)
            {
                workers.Reset();
                workers.MoveNext();
            }
        }
    }
}
