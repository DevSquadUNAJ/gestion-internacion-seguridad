using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Seguridad.Aplicacion.Interfaces;
using Seguridad.Dominio.Entidades;

namespace Seguridad.Infraestructura.Servicios
{
    public class GeneradorToken : IGeneradorToken
    {
        private readonly IConfiguration _configuracion;

        public GeneradorToken(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public string GenerarToken(Usuario usuario)
        {
            string secretKey = _configuracion["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key no configurada");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            if (usuario.EntidadAsociadaId.HasValue)
            {
                claims.Add(new Claim("EntidadAsociadaId", usuario.EntidadAsociadaId.Value.ToString()));
            }

            var token = new JwtSecurityToken(
                issuer: _configuracion["Jwt:Issuer"],
                audience: _configuracion["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
