using MedIapp_API.Datos;
using MedIapp_API.Modelos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedIapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ILogger<PacientesController> _logger;
        private readonly ApplicationDbContext _db;

        public PacientesController(ILogger<PacientesController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
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
            return Ok(_db.Pacientes.ToList());
        }


        [HttpGet("id:int", Name = "GetPaciente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PacientesDTO> GetPacientes(int id)
        {
            _logger.LogInformation("Iniciando la búsqueda del paciente con ID: {Id}", id);

            if (id <= 0)
            {
                _logger.LogWarning("ID inválido: {Id}", id);
                return BadRequest("El ID debe ser mayor que cero.");
            }

            //var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);
            var paciente= _db.Pacientes.FirstOrDefault(x => x.Id == id);

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
                _logger.LogWarning("Modelo inválido.");
                return BadRequest(ModelState);
            }

            // Verificar si ya existe un paciente con la misma identificación
            if (_db.Pacientes.Any(v => v.Identificación == pacientesDTO.Identificacion))
            {
                _logger.LogWarning("Registro existente con la misma identificación.");
                ModelState.AddModelError("Identificacion", "Registro existente con la misma identificación");
                return BadRequest(ModelState);
            }

            if (pacientesDTO == null)
            {
                _logger.LogWarning("El DTO del paciente es nulo.");
                return BadRequest(pacientesDTO);
            }

            // Verificar si ya existe un paciente con el mismo ID
            if (_db.Pacientes.Any(v => v.Id == pacientesDTO.Id))
            {
                _logger.LogWarning("Registro existente con el mismo ID.");
                ModelState.AddModelError("Id", "Registro existente");
                return BadRequest(ModelState);
            }

            // Verificar si ya existe un paciente con la misma combinación de ID y nombre
            if (_db.Pacientes.Any(v => v.Id == pacientesDTO.Id && v.Nombre == pacientesDTO.Nombre))
            {
                _logger.LogWarning("Registro existente con el mismo ID y nombre.");
                ModelState.AddModelError("IdNombre", "Registro existente con el mismo ID y nombre");
                return BadRequest(ModelState);
            }

            if (pacientesDTO.Id > 0)
            {
                _logger.LogError("El ID del paciente ya existe.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //pacientesDTO.Id = _db.Pacientes.OrderByDescending(v => v.Id).FirstOrDefault()?.Id + 1 ?? 1;
            //PacientesMockData.PacientesList.Add(pacientesDTO);

            _logger.LogInformation($"Paciente creado con ID {pacientesDTO.Id}.");

          Paciente modelo = new()
            {
                Id = pacientesDTO.Id,
                Nombre = pacientesDTO.Nombre,
                Apellido = pacientesDTO.Apellido,
                FechaNacimiento = pacientesDTO.FechaNacimiento,
                Direccion = pacientesDTO.Direccion,
                Telefono = pacientesDTO.Telefono,
                Email = pacientesDTO.Email,
                Identificación = pacientesDTO.Identificacion,
                Observacion = pacientesDTO.Observacion,
                Examen = pacientesDTO.Examen,
                ExamenTipo = pacientesDTO.ExamenTipo,
                ExamenNombre = pacientesDTO.ExamenNombre
            };
            _db.Pacientes.Add( modelo );
            _db.SaveChanges();

            return CreatedAtRoute("GetPaciente", new { Id = pacientesDTO.Id, pacientesDTO });

        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeletePaciente(int id)
        {
            _logger.LogInformation("Iniciando el borrado de la información.");
            if (id == 0)
            {
                _logger.LogError("Error: el id ingresado es 0.");
                return BadRequest();
            }

            var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);
            if (paciente == null)
            {
                _logger.LogError($"Error: no se encontró ningún paciente con el id {id}.");
                return NotFound();
            }

            _logger.LogInformation($"Usuario con id {id} borrado.");
            PacientesMockData.PacientesList.Remove(paciente);
            return NoContent();

        }

        [HttpPut ("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePaciente(int id, [FromBody] PacientesDTO pacientesDTO)
        {
            _logger.LogInformation("Iniciando actualización de paciente con ID: {Id}", id);

            if (pacientesDTO == null || id != pacientesDTO.Id)
            {
                _logger.LogWarning("Solicitud inválida. El DTO es nulo o el ID proporcionado no coincide. ID: {Id}", id);
                return BadRequest();
            }

            var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);
            if (paciente == null)
            {
                _logger.LogWarning("Paciente no encontrado con el ID: {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Actualizando datos del paciente con ID: {Id}", id);
            paciente.Nombre = pacientesDTO.Nombre;
            paciente.Apellido = pacientesDTO.Apellido;
            paciente.Identificacion = pacientesDTO.Identificacion;
            paciente.FechaNacimiento = pacientesDTO.FechaNacimiento;
            paciente.Telefono = pacientesDTO.Telefono;
            paciente.Direccion = pacientesDTO.Direccion;
            paciente.Email = pacientesDTO.Email;

            _logger.LogInformation("Paciente con ID: {Id} actualizado correctamente", id);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialPaciente(int id, JsonPatchDocument<PacientesDTO>pacientePatchDto)
        {
            _logger.LogInformation("Iniciando actualización de paciente con ID: {Id}", id);

            if (pacientePatchDto == null || id == 0)
            {
                _logger.LogWarning("Solicitud inválida. El DTO es nulo o el ID proporcionado no coincide. ID: {Id}", id);
                return BadRequest();
            }

            var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);
            if (paciente == null)
            {
                _logger.LogWarning("Paciente no encontrado con el ID: {Id}", id);
                return NotFound();
            }

            try
            {
                _logger.LogInformation("Aplicando patch al paciente con ID: {Id}", id);
                pacientePatchDto.ApplyTo(paciente, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Patch inválido. Problemas de validación con el ModelState. ID: {Id}", id);
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Paciente con ID: {Id} actualizado correctamente", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al aplicar el patch al paciente con ID: {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }




            //_logger.LogInformation("Iniciando actualización de paciente con ID: {Id}", id);

            //if (pacientePatchDto == null || id == 0)
            //{
            //    _logger.LogWarning("Solicitud inválida. El DTO es nulo o el ID proporcionado no coincide. ID: {Id}", id);
            //    return BadRequest();
            //}

            //var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);

            //pacientePatchDto.ApplyTo(paciente, ModelState);

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            //return NoContent();
        }
    }
}








