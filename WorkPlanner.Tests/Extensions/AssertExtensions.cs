using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlanner.V1.DataTransferObjects;
using Xunit;

namespace WorkPlanner.Tests.Extensions
{
    internal class AssertExtensions : Assert
    {
        public static void ValidateShifts(List<ShiftPlanResponseDto> shiftPlan)
        {
            bool hasDuplicate = false;

            foreach (var day in shiftPlan)
            {
                hasDuplicate = day.Shifts.GroupBy(x => x.WorkerId).Where(x => x.Skip(1).Any()).Any();

                if (hasDuplicate)
                    break;
            }

            if (!hasDuplicate)
                return;

            throw new Xunit.Sdk.EqualException(hasDuplicate, false);
        }
    }
}
