using CashFlow_API.DAL.Entities;
using CashFlow_API.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CashFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : Controller
    {
       private readonly IPersonaService _personaService;
        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetCountriesAsync()
        {
            var personas = await _personaService.GetPersonasAsync();
            if (personas == null || !personas.Any())
            {
                return NotFound();
            }
            return Ok(personas);

        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{Cedula}")]
        public async Task<ActionResult<Persona>> GetPersonaByIdAsync(long Cedula)
        {
            var persona = await _personaService.GetPersonaByIdAsync(Cedula);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);

        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Persona>> CreatePersonaAsync(Persona persona)
        {
            try
            {
                var newPersonaawait = await _personaService.CreatePersonaAsync(persona);
                if (newPersonaawait == null)
                {
                    return NotFound();
                }
                return Ok(persona);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", persona.Cedula));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult<Persona>> UpdatePersonaAsync(Persona persona)
        {
            try
            {
                var updatePersona = await _personaService.UpdatePersonaAsync(persona);
                if (updatePersona == null)
                {  
                    return NotFound(); 
                }
                return Ok(updatePersona);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", persona.Cedula));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Persona>> DeletePersonaAsync(long Cedula)
        {
            if (Cedula <= 0) return BadRequest("La cédula debe ser un número positivo válido.");
            var deletedPersona = await _personaService.DeletePersonaAsync(Cedula);
            if (deletedPersona == null) return NotFound("No se encontró una persona con la cédula proporcionada.");
            return Ok("Borrado satisfactoriamente");
        }

    }
}
