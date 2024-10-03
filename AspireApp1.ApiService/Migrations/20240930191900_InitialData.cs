using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    Id_Solicitante = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Solicitante = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fecha_Nacimiento_Solicitante = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.Id_Solicitante);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id_Pago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monto_Pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cuenta_Pago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sucursal_Pago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Referencia_Pago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Banco_Pago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Concepto_Pago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha_Limite_Pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolicitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_Pago_Solicitante_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitante",
                        principalColumn: "Id_Solicitante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Solicitante",
                columns: new[] { "Id_Solicitante", "Fecha_Nacimiento_Solicitante", "Nombre_Solicitante" },
                values: new object[,]
                {
                    { new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56a"), new DateTime(1995, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Pérez" },
                    { new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56b"), new DateTime(1998, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "María López" },
                    { new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56c"), new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Ramírez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pago_SolicitanteId",
                table: "Pago",
                column: "SolicitanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Solicitante");
        }
    }
}
