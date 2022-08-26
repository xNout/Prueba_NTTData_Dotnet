using PRUEBA.BACKEND.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.Interfaces
{
    public interface IPersonaRepositorio : IGenericRepository<Persona>
    {
        Persona? Get(long IdPersona);
    }
}
