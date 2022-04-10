using System;
using System.Collections.Generic;
using WorkPlanner.Constants;
using WorkPlanner.Extensions.Exceptions;
using WorkPlanner.Models.Data;

namespace WorkPlanner.V1.TestableHelpers
{
    public class ShiftServiceHelper
    {


        /// <summary>
        /// Generate worker model
        /// </summary>
        /// <param name="names"></param>
        /// <returns>An enumerable Worker model</returns>
        /// <exception cref="CustomException"></exception>
        public IEnumerable<Worker> GetWorkers(IList<string> names)
        {
            if (names == null || names.Count < 3)
                throw new CustomException("Provide a minimum of 3 worker names");

            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < names.Count; i++)
            {
                workers.Add(new Worker { Id = i + 1, Name = names[i] });
            }

            return workers;
        }

        /// <summary>
        /// Create base shift data for working days
        /// </summary>
        /// <param name="totalDays"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public List<WorkDay> CreateWorkDays(int totalDays)
        {
            if (totalDays == 0)
                throw new CustomException("Provide a minimum of 1 day for shift planning");

            List<WorkDay> workDays = new();

            for (int i = 1; i <= totalDays; i++)
            {
                var dayStart = DateTime.Now.AddDays(i).Date;

                DayShift[] shifts = new DayShift[ShiftConstants.DayShiftCount];

                for (int j = 0; j < shifts.Length; j++)
                {
                    //new shift for work day
                    if (j == 0)
                        shifts[j] = new DayShift() { StartTime = dayStart };
                    //shift's starts when the previous shift ended
                    else
                        shifts[j] = new DayShift() { StartTime = shifts[j - 1].EndTime };
                }

                //easier to read code
                ////shift 1
                //shifts[0] = new()
                //{
                //    StartTime = dayStart,
                //    EndTime = dayStart.AddHours(ShiftConstants.Shift1End)
                //};
                ////shift 2
                //shifts[1] = new()
                //{
                //    StartTime = dayStart.AddHours(ShiftConstants.Shift1End),
                //    EndTime = dayStart.AddHours(ShiftConstants.Shift2End)
                //};
                ////shift 3
                //shifts[2] = new()
                //{
                //    StartTime = dayStart.AddHours(ShiftConstants.Shift2End),
                //    EndTime = dayStart.AddHours(ShiftConstants.Shift3End).AddMinutes(-1)
                //};

                workDays.Add(new() { ShiftDate = dayStart, Shifts = shifts });
            }

            return workDays;
        }
    }
}
