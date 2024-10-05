using LibrosPParcial.Data.Models;

namespace LibrosPParcial.Data.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly BibliotecaContext _context;

        public LibroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Libro> GetAllDispo()
        {
            var libros = _context.Libros.Where(p => p.Disponible == true).ToList();
            return libros;
        }

        public List<Libro> GetBetween(DateTime fechaInicio, DateTime fechaHasta)
        {
            var libros = _context.Libros.Where(p => p.FechaPublicacion >= fechaInicio && p.FechaPublicacion <= fechaHasta).ToList();
            return libros;
        }

        public List<Libro> GetByAutor(string autor)
        {
            var libros = _context.Libros.Where(p => p.Autor.ToLower().Contains(autor.ToLower())).ToList(); // %autor%
            return libros;
        }

        public List<Libro> GetByCategoria(int categoriaId)
        {
            var libros = _context.Libros.Where(p => p.CategoriaId == categoriaId).ToList();
            return libros;
        }

        public bool Save(Libro libro)
        {
            libro.Disponible = true;
            _context.Libros.Add(libro);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateLibro(Libro libro)
        {
            var existe = _context.Libros.Find(libro.LibroId);
            if (existe != null)
            {
                existe.Disponible = false;
                _context.Libros.Update(existe);
                return _context.SaveChanges() > 0;
            }
            else return false;
        }
    }
}
