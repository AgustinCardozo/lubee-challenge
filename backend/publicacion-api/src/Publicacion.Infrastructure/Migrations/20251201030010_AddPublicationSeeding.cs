using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Publicacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicationSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "Age", "Description", "LocationCoordinates", "M2", "OperationType", "PropertyType", "Rooms" },
                values: new object[,]
                {
                    { 3, 10, "Hermosa casa familiar con jardín amplio.", "-34.545388102550206, -58.44912493444169", 250, "Venta", "Casa", 5 },
                    { 4, 0, "Terreno de 800m2 en zona de alto crecimiento, listo para construir.", "-33.15161855419031, -68.89191390749127", 800, "Venta", "Terreno", 0 },
                    { 5, 5, "Oficina moderna en Microcentro, ideal para 5 puestos de trabajo.", "-34.60792311626675, -58.36964480190205", 65, "Alquiler", "Oficina", 3 },
                    { 6, 2, "Monoambiente en Palermo, con balcón y amenities de lujo.", "-34.57966563810134, -58.42070739762831", 45, "Venta", "Departamento", 1 },
                    { 7, 25, "Casa estilo rústico en las afueras, con mucha tranquilidad.", "-34.47886239795676, -58.530800851190776", 300, "Alquiler", "Casa", 6 },
                    { 8, 0, "Lote con servicios al día en barrio cerrado, seguridad 24h.", "-34.386480564005815, -58.70008852211937", 450, "Venta", "Terreno", 0 },
                    { 9, 8, "Espacio de coworking flexible en Belgrano, incluye todos los servicios.", "-34.55660331473092, -58.449894494381375", 90, "Alquiler", "Oficina", 4 },
                    { 10, 50, "PH antiguo reciclado con terraza privada en San Telmo.", "-34.625080194090806, -58.37073447943592", 120, "Venta", "Departamento", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
