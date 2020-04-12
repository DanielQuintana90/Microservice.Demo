using Microservices.Demo.Report.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Domain.Interfaces.Repository
{
    public interface IReportRepository
    {
        Task<List<Policy>> GetPolicies();
    }
}
