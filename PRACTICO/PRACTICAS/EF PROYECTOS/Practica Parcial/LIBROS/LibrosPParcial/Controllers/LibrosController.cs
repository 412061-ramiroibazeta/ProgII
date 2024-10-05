using LibrosPParcial.Data.Models;
using LibrosPParcial.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrosPParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;

        public LibrosController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        [HttpGet]
        public IActionResult GetActivos()
        {
            try
            {
                var libros = _libroRepository.GetAllDispo();
                if (libros != null)
                {
                    return Ok(libros);
                }
                else
                {
                    return StatusCode(404, "No hay libros disponibles");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("{fechaDesde}/{fechaHasta}")]
        public IActionResult GetBetween(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                if (fechaDesde < fechaHasta)
                {
                    var libros = _libroRepository.GetBetween(fechaDesde, fechaHasta);
                    return Ok(libros);
                }
                else return StatusCode(500, "La fecha de inicio debe ser mayor que la fecha de fin");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("{autor}")]
        public IActionResult GetByAutor(string autor)
        {
            try
            {
                if (string.IsNullOrEmpty(autor)) return StatusCode(500, "Debe brindar un autor");
                else
                {
                    var libros = _libroRepository.GetByAutor(autor);
                    if (libros.Count == 0)
                    {
                        return StatusCode(400, "No hay resultados coincidentes");
                    }
                    else return Ok(libros);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPost]
        public IActionResult SaveLibro(Libro libro)
        {
            try
            {
                if (Validar(libro))
                {
                    if (_libroRepository.Save(libro))
                    {
                        return Ok("Se guardó con exito");
                    }
                    else
                    {
                        return StatusCode(500, "Error");
                    }
                }
                else
                {
                    return StatusCode(500, "Un dato del libro no cumple las condiciones para ser guardado");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPatch]
        public IActionResult UpdateLibro(Libro libro)
        {
            try
            {
                if (_libroRepository.UpdateLibro(libro))
                {
                    return Ok("Se actualizo el libro con exito");
                }
                else
                {
                    return StatusCode(500, "Error");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        
        
        
        
        
        private bool Validar(Libro libro)
        {
            bool aux = true;
            if (string.IsNullOrEmpty(libro.Autor) || string.IsNullOrEmpty(libro.Titulo))
            {
                aux = false;
                return aux;
            }
            if(libro.Autor.Length > 100 || libro.Titulo.Length > 100)
            {
                aux = false;
                return aux;
            }
            if(libro.CategoriaId == 0)
            {
                aux = false;
                return aux;
            }            
            return aux;
        }
    }
}


