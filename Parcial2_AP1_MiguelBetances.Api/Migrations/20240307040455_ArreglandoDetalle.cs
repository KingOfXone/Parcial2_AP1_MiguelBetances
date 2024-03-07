using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_AP1_MiguelBetances.Api.Migrations
{
    /// <inheritdoc />
    public partial class ArreglandoDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccesorrioId",
                table: "VehiculosDetalle",
                newName: "AccesorioId");

            migrationBuilder.RenameColumn(
                name: "DetalleId",
                table: "VehiculosDetalle",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Vehiculos",
                newName: "Descripcion");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "VehiculosDetalle",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Gastos",
                table: "Vehiculos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Costo",
                table: "Vehiculos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccesorioId",
                table: "VehiculosDetalle",
                newName: "AccesorrioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehiculosDetalle",
                newName: "DetalleId");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Vehiculos",
                newName: "Descripción");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "VehiculosDetalle",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Gastos",
                table: "Vehiculos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Vehiculos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
