using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MS_PERSONA.Interfaces;
using MS_PERSONA.Domain.Models;

namespace MS_PERSONA.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonasDBEntities _context;


        //Inyeccion depedencia
        public PersonaRepository(PersonasDBEntities context)
        {
            _context = context;
        }

        public IEnumerable<Personas> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Personas GetById(int id)
        {
            return _context.Personas.Find(id);
        }

        public TipoPersonas GetTipoPersonasById(int id)
        {
            return _context.TipoPersonas.Find(id);
        }


        public void Add(Personas persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Update(Personas persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Personas persona)
        {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            
        }

        public bool Exists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }

        public bool EmailExists(string email)
        {
            return _context.Personas.Any(p => p.Email == email);
        }
    }
}
