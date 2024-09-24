using RepositorioTurno.Entities;
using RepositorioTurno.Repositories.Implementations;
using RepositorioTurno.Repositories.Interfaces;
using RepositorioTurno.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioTurno.Services.Implementations
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;

        public TurnoService()
        {
            _turnoRepository = new TurnoRepository();
        }

        public int ContarTurnos(string fecha, string hora)
        {
            return _turnoRepository.ContarTurnos(fecha, hora);
        }

        public bool InsertarMaestroDetalle(Turno turno)
        {
            return _turnoRepository.InsertarMaestroDetalle(turno);
        }

        public List<Servicio> ObtenerServicios()
        {
            return _turnoRepository.ObtenerServicios();
        }
    }
}
