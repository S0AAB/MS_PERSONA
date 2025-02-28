using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using MS_PERSONA.Interfaces;
using MS_PERSONA.Models;

namespace MS_PERSONA.Controllers
{
    public class PersonasController : ApiController
    {
        private readonly IPersonaService _personaService;

        //Inyeccion depedencia
        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET: api/Personas
        [HttpGet]
        public IEnumerable<Personas> GetPersonas()
        {
            return _personaService.GetAll();
        }

        // GET: api/Personas/5
       
        [HttpGet]
        public IHttpActionResult GetPersonas(int id)
        {
            var persona = _personaService.GetById(id);
            if (persona == null)
                return NotFound();

            return Ok(persona);
        }




        [Route("tipos-persona")]
        [HttpGet]
        public IHttpActionResult GetTipoPersonas(int id)
        {
            var tipoPersona = _personaService.GetTipoPersonasById(id);
            if (tipoPersona == null) {
                return NotFound();
            }

            return Ok(tipoPersona);
        }

        // POST: api/Personas
        [HttpPost]
        [ResponseType(typeof(Personas))]
        public IHttpActionResult PostPersonas(Personas persona)
        {   

            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Validacion de email en el servicio
            if (!_personaService.Create(persona))
                return BadRequest("El correo electrónico ya está registrado.");


            //Devuelve la persona creada si es correcto
            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // PUT: api/Personas/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonas(int id, Personas persona)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_personaService.Update(id, persona))
                return NotFound();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Personas/5
        [HttpDelete]
        [ResponseType(typeof(Personas))]
        public IHttpActionResult DeletePersonas(int id)
        {
            if (!_personaService.Delete(id))
                return NotFound();

            return Ok();
        }
    }
}
