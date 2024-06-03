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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<PacientesDTO>> GetPacientes()
        {
            return Ok(PacientesMockData.PacientesList);
        }


        [HttpGet("id:int", Name = "GetPaciente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PacientesDTO> GetPacientes(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var paciente = PacientesMockData.PacientesList.FirstOrDefault(v => v.Id == id);

            if (paciente == null) {

                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost("CrearPaciente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<PacientesDTO> CrearPaciente([FromBody] PacientesDTO pacientesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
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

            // Si pasa ambas validaciones, se puede crear el nuevo registro
            PacientesMockData.PacientesList.Add(pacientesDTO);
            return Ok("Registro creado exitosamente!");


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




