using MedIapp_API.Modelos;

namespace MedIapp_API.Datos
{
    static class PacientesMockData
    {
        public static List<PacientesDTO> PacientesList = new List<PacientesDTO>
        {
                new PacientesDTO { Id = 1, Nombre = "Juan", Apellido = "Pérez", FechaNacimiento = new DateTime(1985, 5, 20), Direccion = "Calle Falsa 123, Ciudad, País", Telefono = "555-1234", Email = "juan.perez@example.com" },
                    new PacientesDTO { Id = 2, Nombre = "María", Apellido = "González", FechaNacimiento = new DateTime(1990, 8, 15), Direccion = "Avenida Siempre Viva 456, Ciudad, País", Telefono = "555-5678", Email = "maria.gonzalez@example.com" },
                    new PacientesDTO { Id = 3, Nombre = "Carlos", Apellido = "López", FechaNacimiento = new DateTime(1978, 3, 10), Direccion = "Boulevard Central 789, Ciudad, País", Telefono = "555-9101", Email = "carlos.lopez@example.com" },
        };
    }
}
