using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Initialize all the Application services
        /// </summary>
        /// <param name="services">Contract collection of service descriptor</param>
        /// <returns>Contract collection of service descriptor</returns>
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
