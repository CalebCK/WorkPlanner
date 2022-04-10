using Microsoft.Extensions.DependencyInjection;
using WorkPlanner.Models.Singleton;
using WorkPlanner.V1.Services;
using WorkPlanner.V1.Services.IServices;

namespace WorkPlanner.IoC
{
    /// <summary>
    /// An extension for Dependency Injections
    /// </summary>
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IShiftService, RegularShiftService>();

            services.AddSingleton(typeof(WorkPlanSingleton<>));
        }
    }
}
