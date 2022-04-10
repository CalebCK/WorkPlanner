using System.Collections.Generic;

namespace WorkPlanner.Models.Singleton
{
    public class WorkPlanSingleton<T> where T : class
    {
        private IList<T> CurrentPlanData { get; set; }

        public void SetCurrentWorkPlan(IList<T> data)
        {
            CurrentPlanData = data;
        }

        public IList<T> GetCurrentWorkPlan()
        {
            return CurrentPlanData;
        }
    }
}
