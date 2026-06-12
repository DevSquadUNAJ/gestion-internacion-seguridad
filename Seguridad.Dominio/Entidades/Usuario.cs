using System;

namespace Seguridad.Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public Guid? EntidadAsociadaId { get; set; }
    }
}
