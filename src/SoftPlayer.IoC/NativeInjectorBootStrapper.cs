using Microsoft.Extensions.DependencyInjection;
using SoftPlayer.Domain.Interest.Commands;
using System;

namespace SoftPlayer.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICalculateInterestRateHandler, CalculateInterestRateCommandHandler>();
        }
    }
}
