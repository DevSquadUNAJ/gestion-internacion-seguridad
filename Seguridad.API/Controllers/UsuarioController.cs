using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Aplicacion.DTOs.Solicitudes;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;

namespace Seguridad.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IObtenerUsuarioActualCasoDeUso _obtenerUsuarioActualCasoDeUso;

        public UsuarioController(IObtenerUsuarioActualCasoDeUso obtenerUsuarioActualCasoDeUso)
        {
            _obtenerUsuarioActualCasoDeUso = obtenerUsuarioActualCasoDeUso;
        }

        [HttpGet("perfil")]
        [ProducesResponseType(typeof(ObtenerUsuarioActualRespuesta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiRespuesta), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorApiRespuesta), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerPerfil()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var usernameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
            var rolClaim = User.FindFirst(ClaimTypes.Role)?.Value;
            var entidadAsociadaIdClaim = User.FindFirst("EntidadAsociadaId")?.Value;

            var solicitud = new ObtenerUsuarioActualSolicitud
            {
                Id = Guid.Parse(idClaim!),
                Username = usernameClaim!,
                Rol = rolClaim!,
                EntidadAsociadaId = entidadAsociadaIdClaim != null ? Guid.Parse(entidadAsociadaIdClaim) : null
            };

            var respuesta = await _obtenerUsuarioActualCasoDeUso.EjecutarAsync(solicitud);

            return Ok(respuesta);
        }
    }
}
