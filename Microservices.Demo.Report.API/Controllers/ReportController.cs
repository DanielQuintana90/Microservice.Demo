using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Demo.Report.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        [Route("GetPolicies")]
        public async Task<ActionResult> GetPolicies()
        {
            var json = new { status = "Funciona el Swagger" };

            return new JsonResult(json);
        }
    }
}
