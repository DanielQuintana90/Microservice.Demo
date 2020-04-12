using Microservices.Demo.Report.API.Application;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly PolicyApplicationService _policyApplicationService;

        public ReportController(PolicyApplicationService policyApplicationService)
        {
            _policyApplicationService = policyApplicationService;
        }

        [HttpGet]
        [Route("GetPolicies")]
        public async Task<ActionResult> GetPolicies()
        {
            return new JsonResult(await _policyApplicationService.GetAllPolicies());
        }
    }
}
