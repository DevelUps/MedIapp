using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedIapp_API.Modelos
{
    public class PacientesDTO
    {


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
        public string Identificacion { get; set; }
    }
}
