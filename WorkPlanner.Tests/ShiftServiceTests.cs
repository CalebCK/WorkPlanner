using System.Linq;
using WorkPlanner.Constants;
using WorkPlanner.Tests.Data;
using WorkPlanner.Tests.Extensions;
using WorkPlanner.V1.DataTransferObjects;
using WorkPlanner.V1.Services;
using WorkPlanner.V1.TestableHelpers;
using Xunit;

namespace WorkPlanner.Tests
{
    public class ShiftServiceTests
    {
        private readonly RegularShiftService _shiftService;
        private ShiftServiceHelper _serviceHelper;
        public ShiftServiceTests()
        {
            _serviceHelper = new ShiftServiceHelper();
            _shiftService = new RegularShiftService();
        }

        [Theory]
        [InlineData(5, 5, (5 * ShiftConstants.DayShiftCount))]
        [InlineData(8, 8, (8 * ShiftConstants.DayShiftCount))]
        [InlineData(2, 2, (2 * ShiftConstants.DayShiftCount))]
        [InlineData(9, 9, (9 * ShiftConstants.DayShiftCount))]
        [InlineData(14, 14, (14 * ShiftConstants.DayShiftCount))]
        [InlineData(22, 22, (22 * ShiftConstants.DayShiftCount))]
        [InlineData(1, 1, (1 * ShiftConstants.DayShiftCount))]
        [InlineData(7, 7, (7 * ShiftConstants.DayShiftCount))]
        [InlineData(40, 40, (40 * ShiftConstants.DayShiftCount))]
        public void CreateWorkDays(int days, int expectedTotalNumberOfDays, int expectedTotalNumberOfShifts)
        {
            //act
            var result = _serviceHelper.CreateWorkDays(days);

            var totalNumberOfDays = result.Count();
            var totalNumberOfShifts = 0;

            result.ForEach(x => { x.Shifts.ToList().ForEach(x => totalNumberOfShifts++); });

            //Assert
            Assert.Equal(expectedTotalNumberOfDays, totalNumberOfDays);
            Assert.Equal(expectedTotalNumberOfShifts, totalNumberOfShifts);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void TestShiftProccess(string[] workerNames, int numberOfDays)
        {
            //arrange
            var request = new ShiftRequestDto() { WorkerNames = workerNames, NumberOfDays = numberOfDays };

            //act
            var response = _shiftService.ProcessRequest(request);

            //assert
            AssertExtensions.ValidateShifts(response);
        }
    }
}
