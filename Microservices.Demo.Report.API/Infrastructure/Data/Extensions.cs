using Microservices.Demo.Report.API.Infrastructure.Data.Context;
using Microservices.Demo.Report.API.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Report.API.Infrastructure.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var reportConnection = configuration.GetConnectionString("ReportConnection");

            services.AddDbContext<ReportDbContext>(options =>
            {
                options.UseSqlServer(reportConnection);
            });
            services.AddScoped<IReportRepository, ReportRepository>();

            return services;
        }
    }
}
