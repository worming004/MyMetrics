using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace MyMetrics.Api.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public Counter GetMetric => Metrics.CreateCounter("my_counter", "my counter", new CounterConfiguration
        {
            LabelNames = new string[] {"tenant", "status"}
        });
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetMetric.WithLabels("Home", "Ok").Inc();
            return Ok("Ok");
        }
        
        [HttpGet("Error")]
        public async Task<IActionResult> GetError()
        {
            GetMetric.WithLabels("Home", "Error").Inc();
            return BadRequest("Error");
        }
    
    }
}