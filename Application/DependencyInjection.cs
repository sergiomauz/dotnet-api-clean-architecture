﻿using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using Application.Commons.Behaviours;
using Application.ErrorCatalog;


namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Initialize all the Application services
        /// </summary>
        /// <param name="services">Contract collection of service descriptor</param>
        /// <returns>Contract collection of service descriptor</returns>
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration)
        {
            //            
            var execAssembly = Assembly.GetExecutingAssembly();

            // Basic services
            services.AddValidatorsFromAssembly(execAssembly);
            services.AddAutoMapper(config =>
            {
                config.AllowNullCollections = true;
                config.ShouldMapField = fieldInfo => true;
            }, execAssembly);
            services.AddMediatR(config => config.RegisterServicesFromAssembly(execAssembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            // Error catalog service
            var errorsCatalogSection = configuration.GetSection("ErrorsCatalog");
            services.Configure<ErrorCatalogConfigurations>(errorsCatalogSection);
            services.AddSingleton<IErrorCatalogService, ErrorCatalogService>();

            //
            return services;
        }
    }
}
