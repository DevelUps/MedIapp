using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedIapp_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarDBPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Apellido", "Direccion", "Email", "Examen", "ExamenNombre", "ExamenTipo", "FechaNacimiento", "Identificación", "Nombre", "Observacion", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Calle Falsa 123", "juan.perez@example.com", new byte[] { 32, 32 }, "examen.pdf", "application/pdf", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345678", "Juan", "Paciente con alergia a la penicilina", "123456789" },
                    { 2, "Pérez", "Calle Falsa 123", "juan.perez@example.com", new byte[] { 32, 32 }, "examen.pdf", "application/pdf", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345678", "Pepito", "Paciente con alergia a la penicilina", "123456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
