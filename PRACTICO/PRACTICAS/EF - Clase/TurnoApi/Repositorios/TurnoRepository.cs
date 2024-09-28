using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TurnoApi.Models;

namespace TurnoApi.Repositorios
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly TurnosDbContext _context;
        public TurnoRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id, string motivo)
        {
            var turno = await _context.TTurnos.FindAsync(id);
            if (turno != null)
            {
                turno.FechaCancelacion = DateTime.Now;
                turno.MotivoCancelacion = motivo;
                _context.TTurnos.Update(turno);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> FindByClientDate(string cliente, DateTime fecha)
        {
            var aux = await _context.TTurnos.Where(x => x.Cliente == cliente && x.Fecha == fecha).ToListAsync();
        }

        public async Task<List<TTurno>>  GetAll()
        {
            return await _context.TTurnos
               .Where(x => !x.FechaCancelacion.HasValue) // x.FechaCancelacion == null
                .ToListAsync();
        }

        public async Task<List<TTurno>> GetCancels(int days)
        {
            DateTime fromDays = DateTime.Now.AddDays(-days);
            return await _context.TTurnos.Where(x => x.FechaCancelacion.HasValue
                                                && x.FechaCancelacion > fromDays).ToListAsync();
        }

        public async Task<bool> Save(TTurno turno)
        {
            _context.TTurnos.Add(turno);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(TTurno turno, int id)
        {
            var entity = await _context.TTurnos.FindAsync(id);
            if (entity == null) return false;
            entity.Cliente = turno.Cliente;
            entity.Fecha = turno.Fecha;
            entity.Hora = turno.Hora;
            _context.TTurnos.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
