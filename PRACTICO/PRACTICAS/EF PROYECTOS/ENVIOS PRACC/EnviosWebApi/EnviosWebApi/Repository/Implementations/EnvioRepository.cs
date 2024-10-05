using EnviosWebApi.Models;
using EnviosWebApi.Repository.Contracts;
using System.Diagnostics.Eventing.Reader;

namespace EnviosWebApi.Repository.Implementations
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly EnviosContext _context;

        public EnvioRepository(EnviosContext context)
        {
            _context = context;
        }

        public bool Delete(int idEnvio)
        {
            var envio = _context.TEnvios.Find(idEnvio);
            if(envio != null)
            {
                envio.Estado = "Cancelado";
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public List<TEnvio> GetByFechaNoCancel(DateTime fechaDesde, DateTime fechaHasta)
        {
            var envios = _context.TEnvios.Where(p => p.FechaEnvio > fechaDesde && p.FechaEnvio < fechaHasta && p.Estado.ToLower() != "cancelado").ToList();
            return envios;
        }

        public bool Save(TEnvio envio)
        {
            var existe = _context.TEnvios.Find(envio.Codigo);

            if (existe == null)
            {
                envio.IdEmpresaNavigation = _context.TEmpresas.Find(envio.IdEmpresa); // IMPORTANTE: PASARLE AL NAVIGATION EL OBJETO EMPRESA
                envio.Estado = "Valido";
                _context.TEnvios.Add(envio);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

    }
}
