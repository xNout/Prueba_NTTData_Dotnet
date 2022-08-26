using PRUEBA.BACKEND.DOMAIN.Entities;
using PRUEBA.BACKEND.DOMAIN.Interfaces;
using PRUEBA.BACKEND.INFRA.REPOSITORY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.INFRA.REPOSITORY.Services
{
    public class PersonaRepositorio : GenericRepository<Persona>, IPersonaRepositorio
    {
        public PersonaRepositorio(DBContexto context) : base(context)
        {
        }

        public Persona? Get(long IdPersona)
        {
            return context.Personas.FirstOrDefault(x => x.IdPersona == IdPersona);
        }
    }
}
