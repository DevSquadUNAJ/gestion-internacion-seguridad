using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguridad.Dominio.Entidades;
using System;

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

            builder.HasData(new Usuario
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Username = "agustin.martinez",
                PasswordHash = "$2a$12$LeuS9i3uiy9rsM6FItlleeXGtoz.AnzI3RpIXH4LjvE3o5.Elhway", // La contraseña cruda es Admision123!
                Rol = "Admision",
                Activo = true,
                EntidadAsociadaId = null
            });

            builder.HasData(new Usuario
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Username = "alejandro.salas",
                PasswordHash = "$2a$12$q5BgJzW8g89Un2g9aSinE.AuQSd8Q/81ZmcorHcp8AmNbSRrmeYby", // La contraseña cruda es Medico123!
                Rol = "Medico",
                Activo = true,
                EntidadAsociadaId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
            });

            builder.HasData(new Usuario
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Username = "yonatan.rojas",
                PasswordHash = "$2a$12$R.JYbHbqzf.2uTvKiSjxGOi6F94wKZsmgm589tTD3XuhgmBoQAVN.", // La contraseña cruda es Medico123!
                Rol = "Medico",
                Activo = true,
                EntidadAsociadaId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")
            });

            builder.HasData(new Usuario
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Username = "rodrigo.godoy",
                PasswordHash = "$2a$12$BBupxtC1rfN.EXFsLthbKeN.LAxOH.LfTSo9LP6kLqr.BKsgMOrvm", // La contraseña cruda es Enfermera123!
                Rol = "Enfermera",
                Activo = true,
                EntidadAsociadaId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd")
            });

            builder.HasData(new Usuario
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Username = "matias.silva",
                PasswordHash = "$2a$12$mgUlpwhxCUQIbOi/gR7mweJx8T1RaqdiCMJCT1iWHWpkXscL/zNY6", // La contraseña cruda es Enfermera123!
                Rol = "Enfermera",
                Activo = true,
                EntidadAsociadaId = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee")
            });
        }
    }
}
