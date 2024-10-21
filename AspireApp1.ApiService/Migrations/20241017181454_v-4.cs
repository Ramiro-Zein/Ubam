using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 12, 14, 53, 302, DateTimeKind.Local).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 12, 14, 53, 302, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 1, 12, 14, 53, 302, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 12, 1, 12, 14, 53, 302, DateTimeKind.Local).AddTicks(5778));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
