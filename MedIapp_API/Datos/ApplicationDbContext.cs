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
    }
}
