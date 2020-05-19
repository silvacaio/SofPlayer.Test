﻿using Microsoft.Extensions.DependencyInjection;

namespace SofPlayer.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {                    
                    Version = "v1",
                    Title = "SoftPlayer API",
                    Description = "Teste de Desenvolvedor .Net Core",                    
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Caio Silva", Email = "silva.caiosfc@hotmail.com" },
                });
            });
        }
    }
}
