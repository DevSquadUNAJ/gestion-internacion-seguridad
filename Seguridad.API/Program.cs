using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Seguridad.Aplicacion.CasosDeUso;
using Seguridad.Aplicacion.Interfaces;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;
using Seguridad.Aplicacion.Interfaces.IConsultas;
using Seguridad.Aplicacion.Interfaces.IMapeadores;
using Seguridad.Aplicacion.Mapeadores;
using Seguridad.Infraestructura.Consultas;
using Seguridad.Infraestructura.Persistencia;
using Seguridad.Infraestructura.Servicios;

namespace Seguridad.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ContextoBaseDeDatos>(opciones =>
                opciones.UseSqlServer(builder.Configuration.GetConnectionString("SeguridadDb")));

            builder.Services.AddScoped<IObtenerUsuarioPorUsernameConsulta, ObtenerUsuarioPorUsernameConsulta>();
            builder.Services.AddScoped<IGeneradorToken, GeneradorToken>();

            builder.Services.AddScoped<IIniciarSesionMapeador, IniciarSesionMapeador>();
            builder.Services.AddScoped<IIniciarSesionCasoDeUso, IniciarSesionCasoDeUso>();

            // Forzar que todas las URLs generadas y expuestas en Swagger sean en minúsculas
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
