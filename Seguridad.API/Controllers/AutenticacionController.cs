using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seguridad.Aplicacion.DTOs.Solicitudes;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;

namespace Seguridad.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IIniciarSesionCasoDeUso _iniciarSesionCasoDeUso;

        public AutenticacionController(IIniciarSesionCasoDeUso iniciarSesionCasoDeUso)
        {
            _iniciarSesionCasoDeUso = iniciarSesionCasoDeUso;
        }

        [HttpPost("iniciar-sesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] IniciarSesionSolicitud solicitud)
        {
            var respuesta = await _iniciarSesionCasoDeUso.EjecutarAsync(solicitud);
            return Ok(respuesta);
        }
    }
}
