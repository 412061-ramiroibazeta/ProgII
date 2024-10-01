using PeluqueriaBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Services.Contracts
{
    public interface IServicioService
    {
        List<Servicio> GetAll();
        Servicio? GetById(int id);
        Servicio? GetByName(string name);
        bool Update(Servicio servicio);
        bool LogicDelete(Servicio servicio);
        bool Save(Servicio servicio);
    }
}
