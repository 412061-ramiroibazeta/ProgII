using Microsoft.AspNetCore.Mvc;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuariosWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        [HttpGet("rol/{id}")]
        public IActionResult GetByRol(int id)
        {
            try
            {
                return Ok(_repository.GetByFillters(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }



        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _repository.Save(usuario);
                return Ok("Usuario agregado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }

        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Error. Datos incompletos.");
                }
                var oUsuario = _repository.GetById(id);
                if ( oUsuario == null)
                {
                    return BadRequest("Error. Usuario no encontrado!");
                }

                oUsuario.Nombre = user.Nombre;
                oUsuario.Clave = user.Clave;
                oUsuario.IdRol = user.IdRol;

                _repository.Save(oUsuario);
                return Ok("Usuario actualizado!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var oUsuario = _repository.GetById(id);
                if (oUsuario == null)
                {
                    return BadRequest("Error. Usuario no encontrado!");
                }

                _repository.Remove(id);
                return Ok("Usuario con datos de baja!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");
            }

        }
    }
}
