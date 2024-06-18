using MedIapp_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MedIapp_API.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        { 
        
        
        }
        
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasData(
                 new Paciente
                 {
                     Id = 1,
                     Nombre = "Juan",
                     Apellido = "Pérez",
                     FechaNacimiento = new DateTime(1990, 5, 23),
                     Direccion = "Calle Falsa 123",
                     Telefono = "123456789",
                     Email = "juan.perez@example.com",
                     Identificación = "DNI12345678",
                     Observacion = "Paciente con alergia a la penicilina",
                     Examen = new byte[] { 0x20, 0x20 }, // Datos binarios de ejemplo para el archivo
                     ExamenTipo = "application/pdf",
                     ExamenNombre = "examen.pdf"
                 },

                 new Paciente
                 {
                     Id = 2,
                     Nombre = "Pepito",
                     Apellido = "Pérez",
                     FechaNacimiento = new DateTime(1990, 5, 23),
                     Direccion = "Calle Falsa 123",
                     Telefono = "123456789",
                     Email = "juan.perez@example.com",
                     Identificación = "DNI12345678",
                     Observacion = "Paciente con alergia a la penicilina",
                     Examen = new byte[] { 0x20, 0x20 }, // Datos binarios de ejemplo para el archivo
                     ExamenTipo = "application/pdf",
                     ExamenNombre = "examen.pdf"
                 },

                  new Paciente
                  {
                      Id = 3,
                      Nombre = "Ana",
                      Apellido = "García",
                      FechaNacimiento = new DateTime(1992, 1, 15),
                      Direccion = "Av. Siempre Viva 742",
                      Telefono = "987654321",
                      Email = "ana.garcia@example.com",
                      Identificación = "DNI12345679",
                      Observacion = "Paciente con diabetes",
                      Examen = new byte[] { 0x20, 0x21 },
                      ExamenTipo = "application/pdf",
                      ExamenNombre = "examen1.pdf"
                  },
                new Paciente
                {
                    Id = 4,
                    Nombre = "Carlos",
                    Apellido = "Mendoza",
                    FechaNacimiento = new DateTime(1988, 7, 22),
                    Direccion = "Calle Luna 123",
                    Telefono = "234567890",
                    Email = "carlos.mendoza@example.com",
                    Identificación = "DNI12345680",
                    Observacion = "Alergia a la penicilina",
                    Examen = new byte[] { 0x20, 0x22 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen2.pdf"
                },
                new Paciente
                {
                    Id = 5,
                    Nombre = "María",
                    Apellido = "López",
                    FechaNacimiento = new DateTime(1985, 11, 5),
                    Direccion = "Calle Flores 456",
                    Telefono = "345678901",
                    Email = "maria.lopez@example.com",
                    Identificación = "DNI12345681",
                    Observacion = "Hipertensión",
                    Examen = new byte[] { 0x20, 0x23 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen3.pdf"
                },
                new Paciente
                {
                    Id = 6,
                    Nombre = "José",
                    Apellido = "Martínez",
                    FechaNacimiento = new DateTime(1975, 3, 8),
                    Direccion = "Calle Sol 789",
                    Telefono = "456789012",
                    Email = "jose.martinez@example.com",
                    Identificación = "DNI12345682",
                    Observacion = "Paciente asmático",
                    Examen = new byte[] { 0x20, 0x24 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen4.pdf"
                },
                new Paciente
                {
                    Id = 7,
                    Nombre = "Lucía",
                    Apellido = "Ramírez",
                    FechaNacimiento = new DateTime(2000, 9, 14),
                    Direccion = "Calle Estrella 321",
                    Telefono = "567890123",
                    Email = "lucia.ramirez@example.com",
                    Identificación = "DNI12345683",
                    Observacion = "Paciente con migrañas",
                    Examen = new byte[] { 0x20, 0x25 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen5.pdf"
                },
                new Paciente
                {
                    Id = 8,
                    Nombre = "Pedro",
                    Apellido = "Gómez",
                    FechaNacimiento = new DateTime(1999, 2, 20),
                    Direccion = "Calle Nube 654",
                    Telefono = "678901234",
                    Email = "pedro.gomez@example.com",
                    Identificación = "DNI12345684",
                    Observacion = "Paciente con hipercolesterolemia",
                    Examen = new byte[] { 0x20, 0x26 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen6.pdf"
                },
                new Paciente
                {
                    Id = 9,
                    Nombre = "Clara",
                    Apellido = "Vega",
                    FechaNacimiento = new DateTime(1991, 8, 30),
                    Direccion = "Calle Mar 987",
                    Telefono = "789012345",
                    Email = "clara.vega@example.com",
                    Identificación = "DNI12345685",
                    Observacion = "Paciente con tiroides",
                    Examen = new byte[] { 0x20, 0x27 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen7.pdf"
                },
                new Paciente
                {
                    Id = 10,
                    Nombre = "Hugo",
                    Apellido = "Díaz",
                    FechaNacimiento = new DateTime(1982, 12, 25),
                    Direccion = "Calle Bosque 258",
                    Telefono = "890123456",
                    Email = "hugo.diaz@example.com",
                    Identificación = "DNI12345686",
                    Observacion = "Paciente con insuficiencia renal",
                    Examen = new byte[] { 0x20, 0x28 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen8.pdf"
                },
                new Paciente
                {
                    Id = 11,
                    Nombre = "Sofía",
                    Apellido = "Blanco",
                    FechaNacimiento = new DateTime(1978, 4, 10),
                    Direccion = "Calle Arcoiris 159",
                    Telefono = "901234567",
                    Email = "sofia.blanco@example.com",
                    Identificación = "DNI12345687",
                    Observacion = "Paciente con artritis",
                    Examen = new byte[] { 0x20, 0x29 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen9.pdf"
                },
                new Paciente
                {
                    Id = 12,
                    Nombre = "Luis",
                    Apellido = "Pérez",
                    FechaNacimiento = new DateTime(1987, 6, 18),
                    Direccion = "Calle Río 852",
                    Telefono = "012345678",
                    Email = "luis.perez@example.com",
                    Identificación = "DNI12345688",
                    Observacion = "Paciente con esclerosis múltiple",
                    Examen = new byte[] { 0x20, 0x30 },
                    ExamenTipo = "application/pdf",
                    ExamenNombre = "examen10.pdf"
                }






                 );


        }
    }
}
