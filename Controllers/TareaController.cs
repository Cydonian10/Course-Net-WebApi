using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;
namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareaController : Controller
    {
        private readonly ILogger<TareaController> _logger;

        ITaskService tareaSrv;
        public TareaController(ILogger<TareaController> logger, ITaskService taskService)
        {
            _logger = logger;
            tareaSrv = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaSrv.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaSrv.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            tareaSrv.Update(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveItem(Guid id)
        {
            tareaSrv.Delete(id);
            return Ok();
        }
    }
}