using TurnoApi.Models;
using TurnoApi.Repositorios;

namespace TurnoApi.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public async Task<bool> ConsultarTurno(string cliente, DateTime fecha)
        {
            return await _turnoRepository.FindByClientDate(cliente, fecha);
        }

        public async Task<bool> Delete(int id,string motivo)
        {
            return await _turnoRepository.Delete(id,motivo);
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _turnoRepository.GetAll();
        }

        public async Task<List<TTurno>> GetCancelados(int dias)
        {
            return await _turnoRepository.GetCancels(dias);
        }

        public async Task<bool> Save(TTurno turno)
        {
            return await _turnoRepository.Save(turno);
        }

        public async Task<bool> Update(TTurno turno, int id)
        {
            return await _turnoRepository.Update(turno,id);
        }
    }
}
