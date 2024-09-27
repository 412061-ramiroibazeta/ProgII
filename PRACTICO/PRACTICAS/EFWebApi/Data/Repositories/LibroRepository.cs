using EFWebApi.Data.Models;

namespace EFWebApi.Data.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private LibrosDBContext _context;

        public LibroRepository(LibrosDBContext context)
        {
            _context = context;
        }
        public void Create(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var libroToDelete = GetById(id);
            if (libroToDelete != null)
            {
                _context.Libros.Remove(libroToDelete);
                _context.SaveChanges();
            }
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public void Update(Libro libro)
        {
            if (libro != null)
            {
                _context.Update(libro);
            }
        }   
    }
}
