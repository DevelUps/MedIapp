using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedIapp_API.Modelos
{
    public class Paciente
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [MaxLength(30)]
            public string Nombre { get; set; }

            [Required]
            [MaxLength(30)]
            public string Apellido { get; set; }

            [Required]
            public DateTime FechaNacimiento { get; set; }

            [MaxLength(100)]
            public string Direccion { get; set; }

            [MaxLength(15)]
            [Phone]
            public string Telefono { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MaxLength(20)]
            public string Identificación { get; set; }

            [MaxLength(250)]
            public string Observacion { get; set; }

            // Campos opcionales para almacenar el archivo
            public byte[] Examen { get; set; } // Archivo del examen en formato binario

        [MaxLength(50)]
            public string ExamenTipo { get; set; } // Tipo de archivo del examen (por ejemplo, 'image/png', 'application/pdf')

        [MaxLength(100)]
            public string ExamenNombre { get; set; }// Nombre del archivo del examen


    }
}
