using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguridad.Dominio.Entidades;

namespace Seguridad.Infraestructura.Persistencia.Configuraciones
{
    public class ConfiguracionUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Rol)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(u => u.EntidadAsociadaId)
                .IsRequired(false);
        }
    }
}
