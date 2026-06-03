using Seguridad.Aplicacion.DTOs.Respuestas;
using Seguridad.Dominio.Entidades;

namespace Seguridad.Aplicacion.Interfaces.IMapeadores
{
    public interface IIniciarSesionMapeador
    {
        IniciarSesionRespuesta MapearARespuesta(Usuario usuario, string token);
    }
}
