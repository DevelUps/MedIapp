using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedIapp_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarDBPaciente10registros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Apellido", "Direccion", "Email", "Examen", "ExamenNombre", "ExamenTipo", "FechaNacimiento", "Identificación", "Nombre", "Observacion", "Telefono" },
                values: new object[,]
                {
                    { 3, "García", "Av. Siempre Viva 742", "ana.garcia@example.com", new byte[] { 32, 33 }, "examen1.pdf", "application/pdf", new DateTime(1992, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345679", "Ana", "Paciente con diabetes", "987654321" },
                    { 4, "Mendoza", "Calle Luna 123", "carlos.mendoza@example.com", new byte[] { 32, 34 }, "examen2.pdf", "application/pdf", new DateTime(1988, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345680", "Carlos", "Alergia a la penicilina", "234567890" },
                    { 5, "López", "Calle Flores 456", "maria.lopez@example.com", new byte[] { 32, 35 }, "examen3.pdf", "application/pdf", new DateTime(1985, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345681", "María", "Hipertensión", "345678901" },
                    { 6, "Martínez", "Calle Sol 789", "jose.martinez@example.com", new byte[] { 32, 36 }, "examen4.pdf", "application/pdf", new DateTime(1975, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345682", "José", "Paciente asmático", "456789012" },
                    { 7, "Ramírez", "Calle Estrella 321", "lucia.ramirez@example.com", new byte[] { 32, 37 }, "examen5.pdf", "application/pdf", new DateTime(2000, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345683", "Lucía", "Paciente con migrañas", "567890123" },
                    { 8, "Gómez", "Calle Nube 654", "pedro.gomez@example.com", new byte[] { 32, 38 }, "examen6.pdf", "application/pdf", new DateTime(1999, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345684", "Pedro", "Paciente con hipercolesterolemia", "678901234" },
                    { 9, "Vega", "Calle Mar 987", "clara.vega@example.com", new byte[] { 32, 39 }, "examen7.pdf", "application/pdf", new DateTime(1991, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345685", "Clara", "Paciente con tiroides", "789012345" },
                    { 10, "Díaz", "Calle Bosque 258", "hugo.diaz@example.com", new byte[] { 32, 40 }, "examen8.pdf", "application/pdf", new DateTime(1982, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345686", "Hugo", "Paciente con insuficiencia renal", "890123456" },
                    { 11, "Blanco", "Calle Arcoiris 159", "sofia.blanco@example.com", new byte[] { 32, 41 }, "examen9.pdf", "application/pdf", new DateTime(1978, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345687", "Sofía", "Paciente con artritis", "901234567" },
                    { 12, "Pérez", "Calle Río 852", "luis.perez@example.com", new byte[] { 32, 48 }, "examen10.pdf", "application/pdf", new DateTime(1987, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "DNI12345688", "Luis", "Paciente con esclerosis múltiple", "012345678" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
