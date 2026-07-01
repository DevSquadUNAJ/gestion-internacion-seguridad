using Seguridad.Dominio.Entidades;

namespace Seguridad.Aplicacion.Interfaces
{
    public interface IGeneradorToken
    {
        string GenerarToken(Usuario usuario);
    }
}
