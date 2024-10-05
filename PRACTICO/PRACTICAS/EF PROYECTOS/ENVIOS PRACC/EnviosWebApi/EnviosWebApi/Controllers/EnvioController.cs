using EnviosWebApi.Models;
using EnviosWebApi.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnviosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioRepository _envioRepository;

        public EnvioController(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        [HttpGet("{fechaDesde}/{fechaHasta}")]
        public ActionResult GetByFechasCancel(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                if (fechaDesde < fechaHasta)
                {
                    // fecha en bd funciona en YMD, ver la forma de pasarselo al swagger / castear la fecha por como la recibo para pasarsela a la bd
                    var envios = _envioRepository.GetByFechaNoCancel(fechaDesde, fechaHasta);
                    return Ok(envios);
                }
                else
                {
                    return StatusCode(500, "La fecha desde debe ser mayor a la fecha hasta");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPost]
        public IActionResult Save(TEnvio envio)
        {
            try
            {
                if (ValidarEnvio(envio))
                {

                    if (_envioRepository.Save(envio))
                    {
                        return Ok("Se guardó correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "Hubo un error al guardar el envio");
                    }
                }
                else
                {
                    return StatusCode(500, "El envio no paso las validaciones");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if(id > 0)
                {
                    if (_envioRepository.Delete(id))
                    {
                        return Ok("La baja logica se efectuo");
                    }
                    else
                    {
                        return StatusCode(500, "Hubo un error al eliminar");
                    }
                }
                else
                {
                    return StatusCode(500, "Enviar un Id valido");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        private bool ValidarEnvio(TEnvio envio)
        {
            bool aux = true;

            if(envio.IdEmpresa == 0)
            {
                aux = true;
                return aux;
            }
            if (string.IsNullOrEmpty(envio.Direccion) || string.IsNullOrEmpty(envio.Direccion) || string.IsNullOrEmpty(envio.Estado) || envio.Direccion.Length > 50 || envio.DniCliente.Length > 50 || envio.Estado.Length > 50)
            {
                aux = true;
                return aux;
            }
            
            return aux;
        }
    }
}
