using Microsoft.AspNetCore.Mvc;
using RepositorioTurno.Entities;
using RepositorioTurno.Services.Implementations;
using RepositorioTurno.Services.Interfaces;

namespace ApiTurnos.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TurnoController : Controller
    {
        private readonly ITurnoService _turnoService;
        public TurnoController()
        {
            _turnoService = new TurnoService();
        }

        [HttpGet("ContarTurnos")]
        public IActionResult GetContar(string fecha, string hora)
        {
            return Ok(_turnoService.ContarTurnos(fecha,hora));
        }

        [HttpGet("servicios")]
        public IActionResult GetServicios()
        {
            return Ok(_turnoService.ObtenerServicios());
        }

        //[HttpPost]
        //public IActionResult PostTurno(Turno turno)
        //{
        //    if (turno != null)
        //    {
                
        //        if(Convert.ToDateTime(turno.Fecha) < DateTime.Now.AddDays(1))
        //        {
        //            return BadRequest("La fecha del turno debe ser mayor a la fecha de hoy");
        //        }
        //        if (Convert.ToDateTime(turno.Fecha) < DateTime.Now.AddDays(45))
        //        {
        //            return BadRequest("La fecha del turno no puede ser mayor a 45 días posteriores a la fecha de hoy");
        //        }

        //    }
        //}

    }
}
