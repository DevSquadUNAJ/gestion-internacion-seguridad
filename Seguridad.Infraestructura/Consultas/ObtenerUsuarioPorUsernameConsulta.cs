using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seguridad.Aplicacion.Interfaces.IConsultas;
using Seguridad.Dominio.Entidades;
using Seguridad.Infraestructura.Persistencia;

namespace Seguridad.Infraestructura.Consultas
{
    public class ObtenerUsuarioPorUsernameConsulta : IObtenerUsuarioPorUsernameConsulta
    {
        private readonly ContextoBaseDeDatos _contexto;

        public ObtenerUsuarioPorUsernameConsulta(ContextoBaseDeDatos contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario?> EjecutarAsync(string username)
        {
            return await _contexto.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}