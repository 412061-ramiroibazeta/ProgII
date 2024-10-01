using UsuariosWebAPI.Models;

namespace UsuariosWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //Necesita de un Contexto para acceder a la base de datos.
        private AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public List<Usuario> GetByFillters(int idRol)
        {
            return _context.Usuarios.Where(x => x.IdRol == idRol).ToList();
        }

        public Usuario? GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Remove(int id)
        {
            var usuario = GetById(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public void Save(Usuario usuario)
        {
           if(usuario != null)
            {
                if(usuario.Id == 0)
                {
                    _context.Usuarios.Add(usuario);
                }
                else
                {
                    _context.Usuarios.Update(usuario);
                }
                _context.SaveChanges();
            }
        }
    }
}
