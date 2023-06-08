
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWordlController : Controller
    {
        private readonly ILogger<HelloWordlController> _logger;
        IHelloWorldService helloWorldService;

        public HelloWordlController(ILogger<HelloWordlController> logger, IHelloWorldService helloworld)
        {
            _logger = logger;
            helloWorldService = helloworld;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }
        

    }
}