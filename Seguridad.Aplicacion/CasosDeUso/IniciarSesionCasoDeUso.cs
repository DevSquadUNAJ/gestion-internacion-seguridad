using System.Threading.Tasks;
using Seguridad.Aplicacion.DTOs.Solicitudes;
using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Aplicacion.Excepciones;
using Seguridad.Aplicacion.Interfaces;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;
using Seguridad.Aplicacion.Interfaces.IConsultas;
using Seguridad.Aplicacion.Interfaces.IMapeadores;

namespace Seguridad.Aplicacion.CasosDeUso
{
    public class IniciarSesionCasoDeUso : IIniciarSesionCasoDeUso
    {
        private readonly IObtenerUsuarioPorUsernameConsulta _consultaUsuario;
        private readonly IGeneradorToken _generadorToken;
        private readonly IIniciarSesionMapeador _mapeador;

        public IniciarSesionCasoDeUso(
            IObtenerUsuarioPorUsernameConsulta consultaUsuario,
            IGeneradorToken generadorToken,
            IIniciarSesionMapeador mapeador)
        {
            _consultaUsuario = consultaUsuario;
            _generadorToken = generadorToken;
            _mapeador = mapeador;
        }

        public async Task<IniciarSesionRespuesta> EjecutarAsync(IniciarSesionSolicitud solicitud)
        {
            var usuario = await _consultaUsuario.EjecutarAsync(solicitud.Username);

            if (usuario == null || !usuario.Activo)
            {
                throw new CredencialesInvalidasException();
            }

            bool passwordValido = BCrypt.Net.BCrypt.Verify(solicitud.Password, usuario.PasswordHash);
            if (!passwordValido)
            {
                throw new CredencialesInvalidasException();
            }

            string token = _generadorToken.GenerarToken(usuario);

            return _mapeador.MapearARespuesta(usuario, token);
        }
    }
}
