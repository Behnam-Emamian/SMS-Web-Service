using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace EmbedIO.Forms.Sample.Controllers
{
    public class HealthCheckController : WebApiController
    {
        public HealthCheckController(IHttpContext context)
        : base(context)
        {
        }

        public override void SetDefaultHeaders() => HttpContext.NoCache();

        [WebApiHandler(HttpVerbs.Get, "/health")]
        public async Task<bool> HealthCheck()
        {
            return await Ok("Healthy",contentType: "text/plain");
        }

    }
}
