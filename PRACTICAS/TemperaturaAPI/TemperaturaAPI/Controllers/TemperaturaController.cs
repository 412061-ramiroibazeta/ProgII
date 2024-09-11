using Microsoft.AspNetCore.Mvc;
using TemperaturaAPI.Models;
using TemperaturaAPI.Utils;

namespace TemperaturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TemperaturaSingleton.GetInstance().GetTemperaturas());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var temp = TemperaturaSingleton.GetInstance().GetById(id);
            if (temp == null)
            {
                return NotFound("no se encontraron resultados");
            }
            else return Ok(temp);
        }

        [HttpPost]
        public IActionResult PostTemp(Temperatura t)
        {
            if (TemperaturaSingleton.GetInstance().Save(t))
                return Ok("Guardado con exito");

            else return BadRequest();
        }
    }
}
