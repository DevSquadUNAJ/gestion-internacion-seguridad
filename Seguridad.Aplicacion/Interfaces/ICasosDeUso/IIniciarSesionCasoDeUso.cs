using System.Threading.Tasks;
using Seguridad.Aplicacion.DTOs.Solicitudes;
using Seguridad.Aplicacion.DTOs.Respuestas;

namespace Seguridad.Aplicacion.Interfaces.ICasosDeUso
{
    public interface IIniciarSesionCasoDeUso
    {
        Task<IniciarSesionRespuesta> EjecutarAsync(IniciarSesionSolicitud solicitud);
    }
}
