using MedIapp_API.Datos;
using MedIapp_API.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace MedIapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ILogger<PacientesController> _logger;

        public PacientesController(ILogger<PacientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<PacientesDTO>> GetAllPacientes()
        {
            _logger.LogInformation("Iniciando la consulta de todos los pacientes.");

            var pacientes = PacientesMockData.PacientesList;

            if (!pacientes.Any())
            {
                _logger.LogWarning("No se encontraron pacientes.");
                return NotFound("No se encontraron pacientes.");
            }

            _logger.LogInformation("Se encontraron {Count} pacientes.", pacientes.Count);
            return Ok(PacientesMockData.PacientesList);
        }


        [HttpGet("id:int", Name = "GetPaciente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PacientesDTO> GetPacientes(int id)
        {
            //_logger.LogInformation("Iniciando la búsqueda del paciente con ID: {Id}", id);

            if (id <= 0)
            {
                _logger.LogWarning("ID inválido: {Id}", id);
                return BadRequest("El ID debe ser mayor que cero.");
            }

            var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);

            if (paciente == null)
            {
                _logger.LogWarning("Paciente no encontrado con ID: {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Paciente encontrado con ID: {Id}", id);
            return Ok(paciente);
            //_logger.LogInformation("Validando todos los pacientes");
            //if (id == 0)
            //{
            //    return BadRequest();
            //}
            //var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);

            //if (paciente == null) {

            //    return NotFound();
            //}
            //return Ok(paciente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<PacientesDTO> CrearPaciente([FromBody] PacientesDTO pacientesDTO)
        {
            _logger.LogInformation("Iniciando la creación de un nuevo paciente.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Verificar si ya existe un paciente con la misma identificación
            if (PacientesMockData.PacientesList.FirstOrDefault(v => v.Identificacion == pacientesDTO.Identificacion) != null)
            {
                ModelState.AddModelError("Identificacion", "Registro existente con la misma identificación");
                return BadRequest(ModelState);
            }

            if (pacientesDTO == null)
            {
                return BadRequest(pacientesDTO);
            }

            // Verificar si ya existe un paciente con el mismo ID
            if (PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == pacientesDTO.Id) != null)
            {
                ModelState.AddModelError("Id", "Registro existente");
                return BadRequest(ModelState);
            }

            // Verificar si ya existe un paciente con la misma combinación de ID y nombre
            if (PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == pacientesDTO.Id && v.Nombre == pacientesDTO.Nombre) != null)
            {
                ModelState.AddModelError("IdNombre", "Registro existente con el mismo ID y nombre");
                return BadRequest(ModelState);
            }


            if (pacientesDTO == null)
            {
                return BadRequest(pacientesDTO);
            }

            if (pacientesDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            pacientesDTO.Id = PacientesMockData.PacientesList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            PacientesMockData.PacientesList.Add(pacientesDTO);

            return CreatedAtRoute("GetPaciente", new { Id = pacientesDTO.Id, pacientesDTO });


        }
    }



}




