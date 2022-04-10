using CurrencyConvertor.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkPlanner.Extensions.Exceptions;
using WorkPlanner.Models.Singleton;
using WorkPlanner.V1.DataTransferObjects;
using WorkPlanner.V1.Services.IServices;

namespace WorkPlanner.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WorkPlanController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        private readonly WorkPlanSingleton<ShiftPlanResponseDto> _planSingleton;

        public WorkPlanController(IShiftService shiftService, WorkPlanSingleton<ShiftPlanResponseDto> planSingleton)
        {
            _shiftService = shiftService;
            _planSingleton = planSingleton;
        }

        /// <summary>
        /// Get last processed work plan
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _planSingleton.GetCurrentWorkPlan();

            if (data == null)
                return NoContent();

            return Ok(data);
        }

        /// <summary>
        /// Make a request to get a number of work days planned for your workers with shifts
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        [HttpPost]
        public IActionResult Post(ShiftRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelException(GlobalFunctions.GetModelStateErrors(ModelState));

            var response = _shiftService.ProcessRequest(requestDto);

            //save plan to allow query
            _planSingleton.SetCurrentWorkPlan(response);

            return Ok(response);
        }
    }
}
