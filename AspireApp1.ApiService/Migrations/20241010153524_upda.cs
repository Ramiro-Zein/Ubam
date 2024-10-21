using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class upda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Alumno",
                table: "Alumno",
                newName: "IdAlumno");

            migrationBuilder.AlterColumn<string>(
                name: "Carrera_Alumno",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "IdAlumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56a"),
                column: "Carrera_Alumno",
                value: "Administración de empresas");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "IdAlumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Carrera_Alumno",
                value: "Gastronomía");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "IdAlumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56c"),
                column: "Carrera_Alumno",
                value: "Derecho");

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 9, 9, 35, 23, 853, DateTimeKind.Local).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 9, 9, 35, 23, 853, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 10, 25, 9, 35, 23, 853, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 24, 9, 35, 23, 853, DateTimeKind.Local).AddTicks(6640));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAlumno",
                table: "Alumno",
                newName: "Id_Alumno");

            migrationBuilder.AlterColumn<int>(
                name: "Carrera_Alumno",
                table: "Alumno",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56a"),
                column: "Carrera_Alumno",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Carrera_Alumno",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56c"),
                column: "Carrera_Alumno",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 7, 9, 46, 50, 35, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 7, 9, 46, 50, 35, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 10, 23, 9, 46, 50, 35, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 22, 9, 46, 50, 35, DateTimeKind.Local).AddTicks(7493));
        }
    }
}
