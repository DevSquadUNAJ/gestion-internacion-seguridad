using System;

namespace Seguridad.Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }

        public Guid? EntidadAsociadaId { get; set; }
    }
}
