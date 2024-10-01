using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UsuariosWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public AppDbContext()
        {    
        }

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Usuario>().Navigation(e => e.Rol).AutoInclude();


            modelBuilder.Entity<Usuario>()
           .HasOne(u => u.Rol)
           .WithMany(r => r.Usuarios)
           .HasForeignKey(u => u.IdRol);


        }
    }
}
