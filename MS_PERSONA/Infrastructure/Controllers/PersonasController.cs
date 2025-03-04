using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MS_PERSONA.Application.Dto;
using MS_PERSONA.Interfaces;



namespace MS_PERSONA.Controllers
{
    public class PersonasController : ApiController
    {
        private readonly IPersonaService _personaService;

        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public IHttpActionResult GetPersonas()
        {
            return Ok(_personaService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetPersonas(int id)
        {
            try
            {
                return Ok(_personaService.GetById(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [Route("tipos-persona/{id}")]
        [HttpGet]
        public IHttpActionResult GetTipoPersonas(int id)
        {
            var tipoPersona = _personaService.GetTipoPersonasById(id);
            if (tipoPersona != null)
            {
                return Ok(tipoPersona);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostPersonas([FromBody] PersonaDto personaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _personaService.Create(personaDto))
            {
                return CreatedAtRoute("DefaultApi", new { id = personaDto.Id }, personaDto);
            }
            else
            {
                return BadRequest("El correo ya está registrado.");
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutPersonas(int id, [FromBody] PersonaDto personaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _personaService.Update(id, personaDto))
            {
                return Ok("Persona actualizada exitosamente.");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletePersonas(int id)
        {
            if (await _personaService.Delete(id))
            {
                return Ok("Persona eliminada correctamente.");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
