using Microservices.Demo.Report.API.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Data.Repository
{
    public interface IReportRepository
    {
        Task<List<Policy>> GetPolicies();
    }
}
