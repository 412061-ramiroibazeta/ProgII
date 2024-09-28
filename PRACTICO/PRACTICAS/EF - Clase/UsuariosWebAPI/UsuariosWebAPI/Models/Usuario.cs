using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuariosWebAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public string Clave { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public virtual Rol? Rol { get; set; }//al colocar? indicamos que el atributo es opcional para EF

    }
}
