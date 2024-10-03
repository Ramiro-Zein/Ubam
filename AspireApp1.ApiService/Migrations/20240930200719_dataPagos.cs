using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class dataPagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "Id_Pago", "Banco_Pago", "Concepto_Pago", "Cuenta_Pago", "Fecha_Limite_Pago", "Monto_Pago", "Referencia_Pago", "SolicitanteId", "Sucursal_Pago" },
                values: new object[,]
                {
                    { new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"), "Banco A", "Inscripción", "1234567890", new DateTime(2024, 10, 30, 14, 7, 19, 343, DateTimeKind.Local).AddTicks(1372), 500m, "REF12345", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56a"), "Sucursal 1" },
                    { new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"), "Banco B", "Colegiatura", "0987654321", new DateTime(2024, 10, 15, 14, 7, 19, 343, DateTimeKind.Local).AddTicks(1425), 300m, "REF67890", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56b"), "Sucursal 2" },
                    { new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"), "Banco C", "Materiales", "1122334455", new DateTime(2024, 11, 14, 14, 7, 19, 343, DateTimeKind.Local).AddTicks(1430), 200m, "REF11223", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56c"), "Sucursal 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"));

            migrationBuilder.DeleteData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"));

            migrationBuilder.DeleteData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"));
        }
    }
}
