using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class v43 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 17, 9, 59, 24, 993, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 17, 9, 59, 24, 993, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 2, 9, 59, 24, 993, DateTimeKind.Local).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 12, 2, 9, 59, 24, 993, DateTimeKind.Local).AddTicks(916));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
