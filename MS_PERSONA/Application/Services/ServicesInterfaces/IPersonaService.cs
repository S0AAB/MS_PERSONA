using System.Collections.Generic;
using System.Threading.Tasks;
using MS_PERSONA.Application.Dto;
using MS_PERSONA.Application.Dto.MS_PERSONA.Application.Dto;


namespace MS_PERSONA.Interfaces
{
    public interface IPersonaService
    {
        IEnumerable<PersonaDto> GetAll();
        PersonaDto GetById(int id);
        TipoPersonaDto GetTipoPersonasById(int id);
        Task<bool> Create(PersonaDto persona);
        Task<bool> Update(int id, PersonaDto persona);
        Task<bool> Delete(int id);
    }
}
