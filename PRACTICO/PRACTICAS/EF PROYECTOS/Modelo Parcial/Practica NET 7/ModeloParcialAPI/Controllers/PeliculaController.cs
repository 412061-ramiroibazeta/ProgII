using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloParcialAPI.Data.Models;
using ModeloParcialAPI.Data.Repository;

namespace ModeloParcialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private IPeliculaRepository _pelicula;

        public PeliculaController(IPeliculaRepository pelicula)
        {
            _pelicula = pelicula;
        }

        [HttpGet]
        public IActionResult GetPeliculas()
        {
            return Ok(_pelicula.GetPeliculas());
        }

        [HttpPost]
        public IActionResult Save(Pelicula p)
        {
            try
            {
                if (Validar(p))
                {
                    _pelicula.Save(p);
                    return Ok("Se ha guardado con exito la pelicula");
                }
                else
                {
                    return StatusCode(500, "Hubo un error, intentelo de nuevo");
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Hubo un error, intentelo de nuevo");
            }
        }

        [HttpPatch]
        public IActionResult Update(int id, string motivo)
        {
            try
            {
                if (id != 0 && motivo != string.Empty)
                {
                    var resultado = _pelicula.Update(id, motivo);
                    return Ok("Se actualizó correctamente: " + resultado);
                }
                else
                {
                    return StatusCode(500, "Hubo un error, intentelo de nuevo");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Hubo un error, intentelo de nuevo");
            }
        }

        [HttpGet("{anioDesde}/{anioHasta}")]
        public IActionResult GetByAnios(int anioDesde, int anioHasta)
        {
            try
            {
                if (anioDesde != 0 && anioHasta != 0 && anioHasta > anioDesde)
                {
                    var pelis = _pelicula.GetFueraEstreno(anioDesde, anioHasta);
                    return Ok(pelis);
                }
                else
                {
                    return StatusCode(500, "Hubo un error, intentelo de nuevo");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Hubo un error, intentelo de nuevo");
            }
        }

        private bool Validar(Pelicula p)
        {
            bool aux = true;
            if (string.IsNullOrEmpty(p.Titulo) || p.Titulo.Length > 50) // 
            {
                aux = false;
            }
            if (string.IsNullOrEmpty(p.Director) || p.Director.Length > 50) // 
            {
                aux = false;
            }
            if (p.Anio <= 0)
            {
                aux = false;
            }
            if (p.IdGenero <= 0)
            {
                aux = false;
            }
            return aux;
        }
    }
}
