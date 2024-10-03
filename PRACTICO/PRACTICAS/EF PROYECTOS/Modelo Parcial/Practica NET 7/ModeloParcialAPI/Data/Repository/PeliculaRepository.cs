using ModeloParcialAPI.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace ModeloParcialAPI.Data.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineContext _context;

        public PeliculaRepository(CineContext context)
        {
            _context = context;
        }

        public List<Pelicula> GetFueraEstreno(int anioDesde, int anioHasta)
        {
            var pelis = _context.Peliculas.Where(p => p.Anio >= anioDesde && p.Anio <= anioHasta).ToList();
            return pelis;
        }

        public List<Pelicula> GetPeliculas()
        {
            var peliculas = _context.Peliculas.Where(p => p.Estreno == true).ToList();
            return peliculas;
        }

        public bool Save(Pelicula p)
        {
            p.FechaBaja = null;
            p.MotivoBaja = null;
            p.Estreno = true;
            _context.Peliculas.Add(p);
            return _context.SaveChanges() > 0;
        }

        public bool Update(int id, string motivo)
        {
            var pelicula = _context.Peliculas.Find(id);

            if (pelicula != null)
            {
                pelicula.Estreno = false;
                pelicula.FechaBaja = DateTime.Now;
                pelicula.MotivoBaja = motivo;

                _context.Peliculas.Update(pelicula);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
