using System.Threading.Tasks;
using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Aplicacion.DTOs.Solicitudes;

namespace Seguridad.Aplicacion.Interfaces.ICasosDeUso
{
    public interface IObtenerUsuarioActualCasoDeUso
    {
        Task<ObtenerUsuarioActualRespuesta> EjecutarAsync(ObtenerUsuarioActualSolicitud solicitud);
    }
}
