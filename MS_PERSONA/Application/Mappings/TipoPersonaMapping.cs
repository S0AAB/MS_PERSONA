﻿
namespace MS_PERSONA.Application.Mappings
{
    using AutoMapper;
    using MS_PERSONA.Application.Dto.MS_PERSONA.Application.Dto;
    
using MS_PERSONA.Domain.Models;

    public class TipoPersonaMapping : Profile
    {
        public TipoPersonaMapping()
        {
            
            CreateMap<TipoPersonas, TipoPersonaDto>().ReverseMap();

            // Ignora coleccion personas
            CreateMap<TipoPersonaDto, TipoPersonas>()
                .ForMember(dest => dest.Personas, opt => opt.Ignore());
        }
    }
}