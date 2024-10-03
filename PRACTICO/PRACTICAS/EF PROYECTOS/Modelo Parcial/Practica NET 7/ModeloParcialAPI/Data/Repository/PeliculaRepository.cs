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

        public List<Pelicula> GetPeliculas()
        {
            var peliculas = _context.Peliculas.Where(p => p.Estreno == true).ToList();
            return peliculas;
        }
    }
}
