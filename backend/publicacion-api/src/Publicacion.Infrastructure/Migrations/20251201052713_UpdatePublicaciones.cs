using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Publicacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePublicaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "M2", "PropertyType" },
                values: new object[] { "Casa con patio y pileta para alquilar en zona tranquila.", 100, "Casa" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Age", "Description", "M2", "PropertyType", "Rooms" },
                values: new object[] { 5, "Departamento para excelente iluminación y ubicado a metros de Plaza Serrano.", 60, "Departamento", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "M2", "PropertyType" },
                values: new object[] { "Departamento de dos ambientes en Villa Crespo", 35, "Departamento" });

            migrationBuilder.UpdateData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Age", "Description", "M2", "PropertyType", "Rooms" },
                values: new object[] { 0, "Terreno de 800m2 en zona de alto crecimiento, listo para construir.", 800, "Terreno", 0 });
        }
    }
}
