using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Publicacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "PublicationId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/58/91/31/1200x1200/2011907562.jpg?isFirstImage=true" },
                    { 2, 1, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/58/91/31/1200x1200/2011907576.jpg" },
                    { 3, 1, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/58/91/31/1200x1200/2011907627.jpg" },
                    { 4, 2, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/52/66/73/1200x1200/2010386134.jpg" },
                    { 5, 2, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/52/66/73/1200x1200/2010386135.jpg?isFirstImage=true" },
                    { 6, 3, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772949.jpg?isFirstImage=true" },
                    { 7, 3, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772950.jpg" },
                    { 8, 3, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772914.jpg" },
                    { 9, 3, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772923.jpg" },
                    { 10, 4, "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/66/47/11/1200x1200/2013893636.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
