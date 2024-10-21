using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAlumno",
                table: "Alumno",
                newName: "Id_Alumno");

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 13, 8, 38, 52, 483, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 13, 8, 38, 52, 483, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 10, 29, 8, 38, 52, 483, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 28, 8, 38, 52, 483, DateTimeKind.Local).AddTicks(8881));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Alumno",
                table: "Alumno",
                newName: "IdAlumno");

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
    }
}
