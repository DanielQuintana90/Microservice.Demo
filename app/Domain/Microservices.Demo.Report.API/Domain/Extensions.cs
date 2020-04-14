using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Report.API.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            //services.AddTransient< , >();

            return services;
        }
    }
}
