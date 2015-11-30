namespace OwinWebAPIMono.Controllers
{
    using System.Web.Http;

    public class HealthCheckController : ApiController
    {
        [Route("health-check")]
        public string Get()
        {
            return "Healthy!";
        }
    }
}