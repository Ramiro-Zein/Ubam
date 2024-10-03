using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class data3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sucursal_Pago",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { new DateTime(2024, 11, 1, 13, 11, 11, 514, DateTimeKind.Local).AddTicks(4625), "Citibanamex" });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { "BBVA", new DateTime(2024, 11, 1, 13, 11, 11, 514, DateTimeKind.Local).AddTicks(4651), "BBVA" });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { new DateTime(2024, 10, 17, 13, 11, 11, 514, DateTimeKind.Local).AddTicks(4646), "BBVA" });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { "BBVA", new DateTime(2024, 11, 16, 13, 11, 11, 514, DateTimeKind.Local).AddTicks(4649), "Citibanamex" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sucursal_Pago",
                table: "Pago",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { new DateTime(2024, 11, 1, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3762), "Sucursal 1" });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { "Banco A", new DateTime(2024, 11, 1, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3821), "Sucursal 1" });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { new DateTime(2024, 10, 17, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3808), "Sucursal 2" });

            migrationBuilder.UpdateData(
                table: "Pago",
                keyColumn: "Id_Pago",
                keyValue: new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"),
                columns: new[] { "Banco_Pago", "Fecha_Limite_Pago", "Sucursal_Pago" },
                values: new object[] { "Banco C", new DateTime(2024, 11, 16, 8, 42, 6, 532, DateTimeKind.Local).AddTicks(3813), "Sucursal 3" });
        }
    }
}
