using Seguridad.Dominio.Entidades;
using System.Threading.Tasks;

namespace Seguridad.Aplicacion.Interfaces.IConsultas
{
    public interface IObtenerUsuarioPorUsernameConsulta
    {
        Task<Usuario> EjecutarAsync(string username);
    }
}
