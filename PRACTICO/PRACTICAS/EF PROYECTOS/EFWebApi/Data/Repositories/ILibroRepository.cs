using EFWebApi.Data.Models;

namespace EFWebApi.Data.Repositories
{
    public interface ILibroRepository
    {
        void Create(Libro libro);
        void Update(Libro libro);
        void Delete(int id);   
        List<Libro> GetAll();
        Libro GetById(int id);
    }
}
