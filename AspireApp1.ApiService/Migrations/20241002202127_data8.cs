using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class data8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago" },
                values: new object[] { "Citibanamex", new DateTime(2024, 11, 1, 14, 21, 26, 934, DateTimeKind.Local).AddTicks(199) });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 1, 14, 21, 26, 934, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago" },
                values: new object[] { "BBVA", new DateTime(2024, 10, 17, 14, 21, 26, 934, DateTimeKind.Local).AddTicks(357) });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 14, 21, 26, 934, DateTimeKind.Local).AddTicks(367));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago" },
                values: new object[] { "BBVA", new DateTime(2024, 11, 1, 14, 19, 40, 137, DateTimeKind.Local).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 1, 14, 19, 40, 137, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago" },
                values: new object[] { "Citibanamex", new DateTime(2024, 10, 17, 14, 19, 40, 137, DateTimeKind.Local).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 14, 19, 40, 137, DateTimeKind.Local).AddTicks(3313));
        }
    }
}
