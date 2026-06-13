using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Seguridad.Aplicacion.CasosDeUso;
using Seguridad.Aplicacion.Interfaces;
using Seguridad.Aplicacion.Interfaces.ICasosDeUso;
using Seguridad.Aplicacion.Interfaces.IConsultas;
using Seguridad.Aplicacion.Interfaces.IMapeadores;
using Seguridad.Aplicacion.Mapeadores;
using Seguridad.Infraestructura.Consultas;
using Seguridad.Infraestructura.Persistencia;
using Seguridad.Infraestructura.Servicios;
using System.Text;

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

            builder.Services.AddScoped<IObtenerUsuarioActualCasoDeUso, ObtenerUsuarioActualCasoDeUso>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opciones =>
                {
                    opciones.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                    };
                });

            // Forzar que todas las URLs generadas y expuestas en Swagger sean en minúsculas
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Pega tu token JWT directamente aquí. (Nota: NO escribas la palabra 'Bearer', Swagger lo agregará por ti automáticamente)."
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        System.Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<Middlewares.ManejadorGlobalExcepcionesMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
