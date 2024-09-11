using Microsoft.AspNetCore.Mvc;
using MonedasApi.Models;
using System.Collections.Generic;

namespace MonedasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaController : Controller
    {

        private readonly static List<Moneda> lst = new List<Moneda>();
        public MonedaController()
        {

        }

        [HttpGet]
        public IActionResult GetMonedas()
        {
            if (lst.Count == 0)
            {
                return NotFound("no se encontraron resultados");
            }
            return Ok(lst);
        }

        [HttpGet("{name}")]
        public IActionResult GetMonedas(string name)
        {
            var moneda = lst.Find(moneda => moneda.Nombre == name);
            if (moneda == null)
            {
                return NotFound("no se encontraron resultados");
            }
            return Ok(moneda);
        }

        [HttpPost]

        public IActionResult PostMoneda([FromBody] Moneda moneda)
        {
            if (moneda != null)
            {
                lst.Add(moneda);
                return Ok(moneda);
            }
            else
            {
                return BadRequest("El objeto no pasó la validación");
            }

        }

    }
}


