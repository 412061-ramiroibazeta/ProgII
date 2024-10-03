using CineAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Data.Repository
{
    public class CineRepository : ICineRepository
    {
        private readonly CineContext _context; //importante es readonly para que no me generen más de una instancia
        public CineRepository(CineContext cine)
        {
            _context = cine;
        }

        public List<Pelicula> GetByFilters(int anioInicio, int anioFin)
        {
            var peliculas = _context.Peliculas.Where(p => p.FechaB)
        }

        public List<Pelicula> GetPeliculas()
        {
            //var peliculas = _context.Peliculas.Where(p => p.Estreno == true).ToList();
            var peliculas = _context.Peliculas.Include(p => p.IdGeneroNavigation).Where(p => p.Estreno == true).ToList(); //include es un join
            return peliculas;
        }

        public bool Save(Pelicula p)
        {
            p.Estreno = true;
            _context.Peliculas.Add(p);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Pelicula p)
        {
            var peliculaActualizada = _context.Peliculas.Find(p);

            if (peliculaActualizada != null)
            {
                peliculaActualizada.Estreno = false;

                _context.Peliculas.Update(peliculaActualizada);

                return _context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
