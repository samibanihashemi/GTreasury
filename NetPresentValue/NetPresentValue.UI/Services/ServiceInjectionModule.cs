using Microsoft.Extensions.DependencyInjection;
using NetPresentValue.Service.CalcUtilty;
using NetPresentValue.UI;

namespace GlobalWeatherReact.Services
{
    public static class ServiceInjectionModule
    {
        /// <summary>
        /// Dependency inject services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorService, CalculatorService>();
            services.AddTransient<ICalculator, NpvCalculator>();
            return services;
        }
    }
}
