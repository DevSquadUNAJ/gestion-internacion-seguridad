using System;

namespace Seguridad.Aplicacion.DTOs.Respuestas
{
    public class IniciarSesionRespuesta
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public Guid? EntidadAsociadaId { get; set; }
    }
}
