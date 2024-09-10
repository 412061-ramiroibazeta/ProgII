using ApiRestPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private static readonly List<Producto> products = new List<Producto>();
        [HttpGet]
        public IActionResult Get()
        {
            products.Add(new Producto() { Codigo = 1, Nombre = "Coca-Cola" });
            return Ok(products);
        }
    }
}
