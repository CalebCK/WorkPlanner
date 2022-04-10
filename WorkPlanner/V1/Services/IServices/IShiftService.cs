using System.Collections.Generic;
using WorkPlanner.V1.DataTransferObjects;

namespace WorkPlanner.V1.Services.IServices
{
    public interface IShiftService
    {
        List<ShiftPlanResponseDto> ProcessRequest(ShiftRequestDto request);
    }
}
