using System.Collections.Generic;
using MS_PERSONA.Interfaces;
using MS_PERSONA.Models;

namespace MS_PERSONA.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;


        //Inyeccion depedencia
        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }



        public IEnumerable<Personas> GetAll()
        {
            return _personaRepository.GetAll();
        }

        public Personas GetById(int id)
        {
            return _personaRepository.GetById(id);
        }

        public TipoPersonas GetTipoPersonasById(int id)
        {
            return _personaRepository.GetTipoPersonasById(id);
        }

        public bool Create(Personas persona)
        {
            if (_personaRepository.EmailExists(persona.Email))
                return false; // Evita duplicados

            _personaRepository.Add(persona);
            return true;
        }

        public bool Update(int id, Personas persona)
        {
            if (!_personaRepository.Exists(id))
                return false;

            _personaRepository.Update(persona);
            return true;
        }

        public bool Delete(int id)
        {
            if (!_personaRepository.Exists(id))
                return false;

            _personaRepository.Delete(id);
            return true;
        }

       
    }
}
