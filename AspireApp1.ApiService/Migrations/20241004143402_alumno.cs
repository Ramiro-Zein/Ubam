using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspireApp1.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class alumno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id_Alumno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Alumno = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Apellido_Paterno_Alumno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Materno_Alumno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Nacimiento_Alumno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo_Alumno = table.Column<int>(type: "int", nullable: false),
                    Carrera_Alumno = table.Column<int>(type: "int", nullable: false),
                    Curp_Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bachillerato_Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado_Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id_Alumno);
                });

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
                    Id_Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Apellido_Paterno_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Materno_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento_Usuario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contrasena_Usuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
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
                    Banco_Pago = table.Column<int>(type: "int", maxLength: 50, nullable: false),
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
                table: "Alumno",
                columns: new[] { "Id_Alumno", "Apellido_Materno_Alumno", "Apellido_Paterno_Alumno", "Bachillerato_Alumno", "Carrera_Alumno", "Curp_Alumno", "Estado_Alumno", "Fecha_Nacimiento_Alumno", "Nombre_Alumno", "Sexo_Alumno" },
                values: new object[,]
                {
                    { new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56a"), "Vega", "Torres", null, 0, null, null, new DateTime(2000, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel", 0 },
                    { new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56b"), "Díaz", "González", null, 2, null, null, new DateTime(2001, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofía", 1 },
                    { new Guid("802c2777-24a5-43ba-b05e-5ffe9a33b56c"), "Mendoza", "Reyes", null, 3, null, null, new DateTime(1999, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego", 0 }
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

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id_Usuario", "Apellido_Materno_Usuario", "Apellido_Paterno_Usuario", "Contrasena_Usuario", "FechaNacimiento_Usuario", "Nombre_Usuario" },
                values: new object[,]
                {
                    { new Guid("702c2777-24a5-43ba-b05e-5ffe9a33b56a"), "Hernández", "García", "password123", new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis" },
                    { new Guid("702c2777-24a5-43ba-b05e-5ffe9a33b56b"), "López", "Martínez", "securepassword", new DateTime(1992, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana" },
                    { new Guid("702c2777-24a5-43ba-b05e-5ffe9a33b56c"), "Ramírez", "Sánchez", "pass456", new DateTime(1988, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "Id_Pago", "Banco_Pago", "Concepto_Pago", "Cuenta_Pago", "Fecha_Limite_Pago", "Monto_Pago", "Referencia_Pago", "SolicitanteId", "Sucursal_Pago" },
                values: new object[,]
                {
                    { new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56b"), 1, "Inscripción", "1234567890", new DateTime(2024, 11, 3, 8, 34, 2, 161, DateTimeKind.Local).AddTicks(6352), 1800m, "REF12345", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56a"), "9865" },
                    { new Guid("102c2777-24a5-43ba-b05e-5ffe9a33b56d"), 0, "Inscripción", "1234567890", new DateTime(2024, 11, 3, 8, 34, 2, 161, DateTimeKind.Local).AddTicks(6402), 1900m, "REF12345", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56c"), "9865" },
                    { new Guid("202c2777-24a5-43ba-b05e-5ffe9a33b56b"), 0, "Colegiatura", "0987654321", new DateTime(2024, 10, 19, 8, 34, 2, 161, DateTimeKind.Local).AddTicks(6394), 2000m, "REF67890", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56b"), "9865" },
                    { new Guid("302c2777-24a5-43ba-b05e-5ffe9a33b56b"), 1, "Materiales", "1122334455", new DateTime(2024, 11, 18, 8, 34, 2, 161, DateTimeKind.Local).AddTicks(6398), 1700m, "REF11223", new Guid("402c2777-24a5-43ba-b05e-5ffe9a33b56c"), "9865" }
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
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Solicitante");
        }
    }
}
