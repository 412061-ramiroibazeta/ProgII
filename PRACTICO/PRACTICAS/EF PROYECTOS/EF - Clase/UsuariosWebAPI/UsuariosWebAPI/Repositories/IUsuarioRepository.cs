using UsuariosWebAPI.Models;

namespace UsuariosWebAPI.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();

        List<Usuario> GetByFillters(int idRol);

        Usuario? GetById(int id);
        void Save(Usuario usuario);
        void Remove(int id);



    }
}
