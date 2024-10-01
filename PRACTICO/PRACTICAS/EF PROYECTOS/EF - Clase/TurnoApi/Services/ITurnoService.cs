using TurnoApi.Models;

namespace TurnoApi.Services
{
    public interface ITurnoService
    {
        Task<List<TTurno>> GetAll();
        //permite recuperar turnos cancelados en los ultimos días.
        Task<List<TTurno>> GetCancelados(int dias);
        Task<bool> Save(TTurno turno);
        Task<bool> Update(TTurno turno, int id);
        Task<bool> Delete(int id, string motivo);
        Task<bool> ConsultarTurno(string cliente, DateTime fecha);
    }
}
