using PRUEBA.BACKEND.DOMAIN.DTOs;
using PRUEBA.BACKEND.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.Interfaces
{
    public interface IClienteRepositorio : IGenericRepository<Cliente>
    {
        bool Exists(long IdCliente);
        IEnumerable<CreatedClientResponseAppDto> GetAllDtos();
        Cliente? Get(long IdCliente);
        bool ExistsByNombre(string Nombre);
    }
}
