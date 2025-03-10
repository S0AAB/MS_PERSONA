using AutoMapper;
using MS_PERSONA.Application.Dto;
using MS_PERSONA.Domain.Models;



namespace MS_PERSONA.Application.Mappings
{
	public class PersonaMapping: Profile
    {
        public PersonaMapping()
        {
            
            CreateMap<Personas, PersonaDto>().ReverseMap();

                   
        }
    }   

}

