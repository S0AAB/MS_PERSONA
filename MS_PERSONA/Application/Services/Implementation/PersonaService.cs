using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MS_PERSONA.Application.Dto;
using MS_PERSONA.Application.Dto.MS_PERSONA.Application.Dto;
using MS_PERSONA.Interfaces;
using MS_PERSONA.Domain.Models;

namespace MS_PERSONA.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public IEnumerable<PersonaDto> GetAll()
        {
            var personas = _personaRepository.GetAll();
            return _mapper.Map<IEnumerable<PersonaDto>>(personas);
        }

        public PersonaDto GetById(int id)
        {
            var persona = _personaRepository.GetById(id);
            if (persona == null)
                throw new KeyNotFoundException("No se encontró la persona.");

            return _mapper.Map<PersonaDto>(persona);
        }

        public TipoPersonaDto GetTipoPersonasById(int id)
        {
            return _mapper.Map<TipoPersonaDto>(_personaRepository.GetTipoPersonasById(id));
        }

        public async Task<bool> Create(PersonaDto personaDto)
        {
            if (_personaRepository.EmailExists(personaDto.Email))
                return false;

            var persona = _mapper.Map<Personas>(personaDto);
            _personaRepository.Add(persona);
            return true;
        }

        public async Task<bool> Update(int id, PersonaDto personaDto)
        {
            if (!_personaRepository.Exists(id))
                return false;

            var persona = _personaRepository.GetById(id);
            

            //Verificacion de email no utilizado al actualizar
            if ((_personaRepository.EmailExists(persona.Email)) && (personaDto.Email!=persona.Email))
                return false;

            var idAntiguo = persona.Id;
            _mapper.Map(personaDto, persona);

            //Mantiene el mismo ID en caso de que se cambie en el body
            persona.Id = idAntiguo;
            _personaRepository.Update(persona);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (!_personaRepository.Exists(id))
                return false;

            var persona = _personaRepository.GetById(id);
            _personaRepository.Delete(persona);

            return true;
        }
    }
}
