using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiLINQ.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ciudad",
                columns: new[] { "idCiudad", "nombreCiudad" },
                values: new object[,]
                {
                    { 1, "Leon" },
                    { 2, "Puri" },
                    { 3, "Silao" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudad",
                keyColumn: "idCiudad",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudad",
                keyColumn: "idCiudad",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ciudad",
                keyColumn: "idCiudad",
                keyValue: 3);
        }
    }
}
