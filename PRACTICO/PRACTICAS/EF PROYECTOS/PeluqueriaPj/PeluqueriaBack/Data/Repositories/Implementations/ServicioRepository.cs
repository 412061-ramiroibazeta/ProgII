using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaBack.Data.Repositories.Implementations
{
    public class ServicioRepository : IServicioRepository
    {
        private TurnosDBContext _context;

        public ServicioRepository(TurnosDBContext context)
        {
            _context = context;
        }

        public List<Servicio> GetAll()
        {
            return _context.Servicios.ToList();
        }

        public Servicio? GetById(int id)
        {
            return _context.Servicios.Find(id);
        }

        public Servicio? GetByName(string name)
        {
            return _context.Servicios.FirstOrDefault(e => e.Nombre == name);
        }

        public bool LogicDelete(Servicio servicio)
        {
            var s = _context.Servicios.FirstOrDefault(e => e.Id == servicio.Id);

            if (s != null)
            {
                try
                {
                    s.EnPromocion = string.Empty;
                    s.Costo = 0;

                    _context.Servicios.Update(s);
                    return _context.SaveChanges() > 0;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else return false;
        }

        public bool Save(Servicio servicio)
        {
            if (servicio != null)
            {
                try
                {
                    _context.Servicios.Add(servicio);
                    return _context.SaveChanges() > 0;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            else return false;
        }

        public bool Update(Servicio servicio)
        {
            var actualizar = _context.Servicios.Find(servicio.Id);
            if (actualizar != null)
            {
                _context.Entry(actualizar).CurrentValues.SetValues(servicio);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
