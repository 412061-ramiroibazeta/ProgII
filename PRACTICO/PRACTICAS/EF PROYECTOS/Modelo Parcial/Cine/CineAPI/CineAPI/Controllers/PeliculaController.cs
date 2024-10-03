using CineAPI.Data.Models;
using CineAPI.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ICineRepository _cineRepository;

        public PeliculaController(ICineRepository cineRepository)
        {
            _cineRepository = cineRepository;
        }

        [HttpGet]
        public IActionResult GetPeliculas()
        {
            try
            {
                var peliculas = _cineRepository.GetPeliculas();
                if (peliculas == null)
                {
                    return NotFound();
                }
                return Ok(peliculas);
            }
            catch (Exception)
            {
                return StatusCode(500, "No se encontró");
            }
        }
        [HttpPost]
        public IActionResult Save(Pelicula p)
        {
            if (ValidarPeli(p))
            {
                _cineRepository.Save(p);
                return Ok("La pelicula se guardo exitosamente");
            }
            else
            {
                return BadRequest("Hubo un error en los datos de la pelicula");
            }
        }
        private bool ValidarPeli(Pelicula p)
        {
            return (!string.IsNullOrEmpty(p.Titulo) && !string.IsNullOrEmpty(p.Director) && p.Anio > 0 && p.IdGenero > 0);
        }

        [HttpPatch]
        public IActionResult Update(Pelicula p)
        {
            if (_cineRepository.Update(p))
            {
                return Ok("Se quito la pelicula de cartelera");
            }
            else
            {
                return StatusCode(500, "Hubo un error");
            }
        }

    }
}
