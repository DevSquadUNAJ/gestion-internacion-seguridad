using System.Threading.Tasks;
using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Aplicacion.DTOs.Solicitudes;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;

namespace Seguridad.Aplicacion.CasosDeUso
{
    public class ObtenerUsuarioActualCasoDeUso : IObtenerUsuarioActualCasoDeUso
    {
        public Task<ObtenerUsuarioActualRespuesta> EjecutarAsync(ObtenerUsuarioActualSolicitud solicitud)
        {
            var respuesta = new ObtenerUsuarioActualRespuesta
            {
                Id = solicitud.Id,
                Username = solicitud.Username,
                Rol = solicitud.Rol,
                EntidadAsociadaId = solicitud.EntidadAsociadaId
            };

            return Task.FromResult(respuesta);
        }
    }
}
