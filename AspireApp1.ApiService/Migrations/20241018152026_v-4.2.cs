using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class v42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo_Alumno",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56a"),
                column: "Sexo_Alumno",
                value: "Masculino");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Sexo_Alumno",
                value: "Femenino");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56c"),
                column: "Sexo_Alumno",
                value: "Masculino");

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 17, 9, 20, 25, 680, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 17, 9, 20, 25, 680, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 2, 9, 20, 25, 680, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 12, 2, 9, 20, 25, 680, DateTimeKind.Local).AddTicks(8544));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sexo_Alumno",
                table: "Alumno",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56a"),
                column: "Sexo_Alumno",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Sexo_Alumno",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "Id_Alumno",
                keyValue: new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56c"),
                column: "Sexo_Alumno",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 12, 25, 46, 63, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 12, 25, 46, 63, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 1, 12, 25, 46, 63, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 12, 1, 12, 25, 46, 63, DateTimeKind.Local).AddTicks(9291));
        }
    }
}
