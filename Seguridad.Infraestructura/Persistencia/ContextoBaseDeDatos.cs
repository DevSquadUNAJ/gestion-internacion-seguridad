using Microsoft.EntityFrameworkCore;
using Seguridad.Dominio.Entidades;
using System.Reflection;


namespace Seguridad.Infraestructura.Persistencia
{
    public class ContextoBaseDeDatos : DbContext
    {
        public ContextoBaseDeDatos(DbContextOptions<ContextoBaseDeDatos> opciones) : base(opciones)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
