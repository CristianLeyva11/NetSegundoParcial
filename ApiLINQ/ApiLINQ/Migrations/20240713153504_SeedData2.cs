using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiLINQ.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "idDepartamento", "descripcion", "nombreDepartamento" },
                values: new object[,]
                {
                    { 1, "Aqui hacen tickets Jaja (Mucho ojo con la Coordi).", "Tickets" },
                    { 2, "Aqui hacen cosas de Logistica Duh!", "Logistica" },
                    { 3, "Aqui hacen Pan, o no se, nunca le supe a la administracion.", "Administrativo" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "idEmpleado", "fechaIngreso", "idCiudad", "nombreEmpleado", "puesto", "sueldo" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 13, 9, 35, 3, 386, DateTimeKind.Local).AddTicks(39), 1, "Mario Zuniga", "Desarrollador", 1600.0 },
                    { 2, new DateTime(2024, 7, 13, 9, 35, 3, 386, DateTimeKind.Local).AddTicks(53), 2, "Cristian Leyva", "Desarrollador", 3200.0 },
                    { 3, new DateTime(2024, 7, 13, 9, 35, 3, 386, DateTimeKind.Local).AddTicks(56), 2, "Emmanuel Escobedo", "Desarrollador", 3200.0 },
                    { 4, new DateTime(2024, 7, 13, 9, 35, 3, 386, DateTimeKind.Local).AddTicks(58), 3, "Brenda Gutierrez", "Desarrollador", 3200.0 },
                    { 5, new DateTime(2024, 7, 13, 9, 35, 3, 386, DateTimeKind.Local).AddTicks(60), 1, "Pedro Morales", "Desarrollador", 3200.0 },
                    { 6, new DateTime(2024, 7, 13, 9, 35, 3, 386, DateTimeKind.Local).AddTicks(64), 1, "Israel Lopez", "Desarrollador", 3200.0 }
                });

            migrationBuilder.InsertData(
                table: "EmpleadoDepartamento",
                columns: new[] { "idDepartamento", "idEmpleado" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmpleadoDepartamento",
                keyColumns: new[] { "idDepartamento", "idEmpleado" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmpleadoDepartamento",
                keyColumns: new[] { "idDepartamento", "idEmpleado" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EmpleadoDepartamento",
                keyColumns: new[] { "idDepartamento", "idEmpleado" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EmpleadoDepartamento",
                keyColumns: new[] { "idDepartamento", "idEmpleado" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "EmpleadoDepartamento",
                keyColumns: new[] { "idDepartamento", "idEmpleado" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "EmpleadoDepartamento",
                keyColumns: new[] { "idDepartamento", "idEmpleado" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "Departamento",
                keyColumn: "idDepartamento",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departamento",
                keyColumn: "idDepartamento",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departamento",
                keyColumn: "idDepartamento",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "idEmpleado",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "idEmpleado",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "idEmpleado",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "idEmpleado",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "idEmpleado",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Empleado",
                keyColumn: "idEmpleado",
                keyValue: 6);
        }
    }
}
