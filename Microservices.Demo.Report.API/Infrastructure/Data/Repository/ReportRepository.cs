using Microservices.Demo.Report.API.Infrastructure.Data.Context;
using Microservices.Demo.Report.API.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Infrastructure.Data.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportDbContext _reportDbContext;
        public ReportRepository(ReportDbContext reportDbContext)
        {
            _reportDbContext = reportDbContext ?? throw new ArgumentNullException(nameof(reportDbContext));
        }

        public async Task<List<Policy>> GetPolicies()
        {
            return await _reportDbContext.Policy.ToListAsync();
        }
    }
}
