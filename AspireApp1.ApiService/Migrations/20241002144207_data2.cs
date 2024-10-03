using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 1, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 10, 17, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 16, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "Id_Pago", "Banco_Pago", "Concepto_Pago", "Cuenta_Pago", "Fecha_Limite_Pago", "Monto_Pago", "Referencia_Pago", "SolicitanteId", "Sucursal_Pago" },
                values: new object[] { new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"), "Banco A", "Inscripción", "1234567890", new DateTime(2024, 11, 1, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3821), 700m, "REF12345", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56c"), "Sucursal 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 10, 30, 14, 13, 31, 167, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 10, 15, 14, 13, 31, 167, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                column: "Fecha_Limite_Pago",
                value: new DateTime(2024, 11, 14, 14, 13, 31, 167, DateTimeKind.Local).AddTicks(5840));
        }
    }
}
