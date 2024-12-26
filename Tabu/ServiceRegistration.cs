using FluentValidation.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Tabu.Exceptions;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {


            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IGameService, GameService>();
            return services;    
        
        }

        public static IApplicationBuilder UseTabuExceptionHandler(this IApplicationBuilder app) {

            app.UseExceptionHandler(opt =>
            {
                opt.Run(async context =>
                {
                    var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                    var exception = feature.Error;
                    if (exception is IBaseException bEx)
                    {
                        context.Response.StatusCode = bEx.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = bEx.ErrorMessage
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = "Unknown situation"
                        });
                    }

                });

            });
            return app;

        }

       
    }
}
