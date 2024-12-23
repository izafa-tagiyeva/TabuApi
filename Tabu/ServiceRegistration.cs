﻿using FluentValidation.Resources;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {


            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            return services;    
        
        }
    }
}
