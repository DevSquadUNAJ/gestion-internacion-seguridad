using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Aplicacion.DTOs.Solicitudes;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(IniciarSesionRespuesta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiRespuesta), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorApiRespuesta), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSesion([FromBody] IniciarSesionSolicitud solicitud)
        {
            var respuesta = await _iniciarSesionCasoDeUso.EjecutarAsync(solicitud);
            return Ok(respuesta);
        }
    }
}
