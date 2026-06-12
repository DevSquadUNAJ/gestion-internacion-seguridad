using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Seguridad.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class InicializacionSeguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EntidadAsociadaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "EntidadAsociadaId", "PasswordHash", "Rol", "Username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), true, null, "$2a$12$LeuS9i3uiy9rsM6FItlleeXGtoz.AnzI3RpIXH4LjvE3o5.Elhway", "Admision", "agustin.martinez" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "$2a$12$q5BgJzW8g89Un2g9aSinE.AuQSd8Q/81ZmcorHcp8AmNbSRrmeYby", "Medico", "alejandro.salas" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "$2a$12$R.JYbHbqzf.2uTvKiSjxGOi6F94wKZsmgm589tTD3XuhgmBoQAVN.", "Medico", "yonatan.rojas" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "$2a$12$BBupxtC1rfN.EXFsLthbKeN.LAxOH.LfTSo9LP6kLqr.BKsgMOrvm", "Enfermera", "rodrigo.godoy" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "$2a$12$mgUlpwhxCUQIbOi/gR7mweJx8T1RaqdiCMJCT1iWHWpkXscL/zNY6", "Enfermera", "matias.silva" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
