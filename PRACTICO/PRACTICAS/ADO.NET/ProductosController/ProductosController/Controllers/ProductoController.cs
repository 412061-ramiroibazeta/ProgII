using Microsoft.AspNetCore.Mvc;
using ProductosController.Models;
using ProductosController.Services;

namespace ProductosController.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IAplicacion _producto;
        public ProductoController()
        {
            _producto = new ProductoService();
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_producto.GetProductos());
        }

        [HttpPost]
        public IActionResult Post(Productos p)
        {
            var result = _producto.AgregarProducto(p);
            return Ok(result);
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _producto.EliminarProducto(id);
            return Ok(result);
        }
    }
}
