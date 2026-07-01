using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Aplicacion.Interfaces.IMapeadores;
using Seguridad.Dominio.Entidades;

namespace Seguridad.Aplicacion.Mapeadores
{
    public class IniciarSesionMapeador : IIniciarSesionMapeador
    {
        public IniciarSesionRespuesta MapearARespuesta(Usuario usuario, string token)
        {
            return new IniciarSesionRespuesta
            {
                Token = token,
                Username = usuario.Username,
                Rol = usuario.Rol,
                EntidadAsociadaId = usuario.EntidadAsociadaId
            };
        }
    }
}