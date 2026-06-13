using System;

namespace Seguridad.Aplicacion.DTOs.Respuestas
{
    public class ObtenerUsuarioActualRespuesta
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public Guid? EntidadAsociadaId { get; set; }
    }
}
