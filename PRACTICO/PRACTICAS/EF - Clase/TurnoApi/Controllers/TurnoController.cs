using Microsoft.AspNetCore.Mvc;
using TurnoApi.Models;
using TurnoApi.Services;

namespace TurnoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : Controller
    {
        private readonly ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _turnoService.GetAll());
        }

        [HttpGet("Cancelador/{days}")]
        public async Task<IActionResult> GetAll(int days)
        {
            return Ok(await _turnoService.GetCancelados(days));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TTurno turno)
        {
            return Ok(await _turnoService.Save(turno));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery]int id,[FromBody] TTurno turno)
        {
            return Ok(await _turnoService.Update(turno,id));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] string motivo)
        {
            return Ok(await _turnoService.Delete(id,motivo));
        }
    }
}
