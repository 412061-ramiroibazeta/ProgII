using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using PeluqueriaBack.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Services.Implementations
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _service;
        public ServicioService(IServicioRepository service)
        {
            _service = service;
        }
        public List<Servicio> GetAll()
        {
            return _service.GetAll();
        }

        public Servicio? GetById(int id)
        {
            return _service.GetById(id);
        }

        public Servicio? GetByName(string name)
        {
            return _service.GetByName(name);
        }

        public bool LogicDelete(Servicio servicio)
        {
            return _service.LogicDelete(servicio);
        }

        public bool Save(Servicio servicio)
        {
            return _service.Save(servicio);
        }

        public bool Update(Servicio servicio)
        {
            return _service.Update(servicio);
        }
    }
}
