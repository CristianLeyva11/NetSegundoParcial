using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal_API___Empresa.Migrations
{
    /// <inheritdoc />
    public partial class Inicialaaapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoDepartamentos_Departamentos_Departamentold",
                table: "EmpleadoDepartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoDepartamentos_Empleados_Empleadold",
                table: "EmpleadoDepartamentos");

            migrationBuilder.RenameColumn(
                name: "Empleadold",
                table: "Empleados",
                newName: "EmpleadoId");

            migrationBuilder.RenameColumn(
                name: "Departamentold",
                table: "EmpleadoDepartamentos",
                newName: "DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "Empleadold",
                table: "EmpleadoDepartamentos",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_EmpleadoDepartamentos_Departamentold",
                table: "EmpleadoDepartamentos",
                newName: "IX_EmpleadoDepartamentos_DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "Departamentold",
                table: "Departamentos",
                newName: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoDepartamentos_Departamentos_DepartamentoId",
                table: "EmpleadoDepartamentos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoDepartamentos_Empleados_EmpleadoId",
                table: "EmpleadoDepartamentos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoDepartamentos_Departamentos_DepartamentoId",
                table: "EmpleadoDepartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadoDepartamentos_Empleados_EmpleadoId",
                table: "EmpleadoDepartamentos");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Empleados",
                newName: "Empleadold");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "EmpleadoDepartamentos",
                newName: "Departamentold");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "EmpleadoDepartamentos",
                newName: "Empleadold");

            migrationBuilder.RenameIndex(
                name: "IX_EmpleadoDepartamentos_DepartamentoId",
                table: "EmpleadoDepartamentos",
                newName: "IX_EmpleadoDepartamentos_Departamentold");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Departamentos",
                newName: "Departamentold");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoDepartamentos_Departamentos_Departamentold",
                table: "EmpleadoDepartamentos",
                column: "Departamentold",
                principalTable: "Departamentos",
                principalColumn: "Departamentold",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadoDepartamentos_Empleados_Empleadold",
                table: "EmpleadoDepartamentos",
                column: "Empleadold",
                principalTable: "Empleados",
                principalColumn: "Empleadold",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
