using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Contracts
{
    public interface ITurnoRepository
    { 
        List<Turno> GetAll();
        Turno FindById(int id);
        Turno GetByFecha(DateTime fecha);
        Turno GetByHora(string hora);
        List<Turno> TurnosByCliente();
        bool Save(Turno turno);
        bool Update(Turno turno);
        bool Delete(Turno turno);


    }
}
