using System.Collections.Generic;
using MS_PERSONA.Models;

namespace MS_PERSONA.Interfaces
{
    public interface IPersonaRepository
    {
        IEnumerable<Personas> GetAll();
        Personas GetById(int id);
        TipoPersonas GetTipoPersonasById(int id);
        void Add(Personas persona);
        void Update(Personas persona);
        void Delete(int id);
        bool Exists(int id);
        bool EmailExists(string email);
    }
}