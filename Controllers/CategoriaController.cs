using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        ICategoriaService categoriaSrv;
        public CategoriaController(ILogger<CategoriaController> logger , ICategoriaService categoriaService)
        {
            _logger = logger;
            categoriaSrv = categoriaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriaSrv.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {    
            categoriaSrv.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put( Guid id ,[FromBody] Categoria categoria)
        {
            categoriaSrv.Update(id,categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveItem(Guid id)
        {
            categoriaSrv.Delete(id);
            return Ok();
        }
    }
}