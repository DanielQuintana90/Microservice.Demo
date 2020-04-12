using Microservices.Demo.Report.API.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet]
        [Route("GetPolicies")]
        public async Task<ActionResult> GetPolicies()
        {
            return new JsonResult(await reportRepository.GetPolicies());
        }
    }
}
