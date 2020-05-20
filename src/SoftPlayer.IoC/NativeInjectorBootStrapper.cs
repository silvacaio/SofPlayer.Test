using Microsoft.Extensions.DependencyInjection;
using SoftPlayer.Application.Handlers;
using SoftPlayer.Application.Handlers.Interest;
using SoftPlayer.Domain.Core.Handler;
using SoftPlayer.Domain.Interest.Handlers;
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
