﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_PERSONA.Application.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoPersonaId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }
}