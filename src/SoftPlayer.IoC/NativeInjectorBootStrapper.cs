using Microsoft.Extensions.DependencyInjection;
using SoftPlayer.Domain.Core.Handler;
using SoftPlayer.Domain.Interest.Commands;
using System;

namespace SoftPlayer.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Handlers            

            services.AddHttpClient<IHttpHandler, HttpClientHandler>()
             .SetHandlerLifetime(TimeSpan.FromMinutes(5));


            services.AddScoped<IGetInterestRateCommandHandler, GetInterestRateCommandHandler>();
            services.AddScoped<ICalculateInterestRateHandler, CalculateInterestCommandHandler>();
        }
    }
}
