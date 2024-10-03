using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
