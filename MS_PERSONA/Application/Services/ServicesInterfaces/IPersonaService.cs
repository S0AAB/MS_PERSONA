using System.Collections.Generic;
using MS_PERSONA.Models;

namespace MS_PERSONA.Interfaces
{
    public interface IPersonaService
    {
        IEnumerable<Personas> GetAll();
        Personas GetById(int id);
        TipoPersonas GetTipoPersonasById(int id);
        bool Create(Personas persona);
        bool Update(int id, Personas persona);
        bool Delete(int id);
    }
}
