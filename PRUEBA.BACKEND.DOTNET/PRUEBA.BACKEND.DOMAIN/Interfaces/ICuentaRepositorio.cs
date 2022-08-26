using PRUEBA.BACKEND.DOMAIN.DTOs;
using PRUEBA.BACKEND.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.Interfaces
{
    public interface ICuentaRepositorio : IGenericRepository<Cuenta>
    {
        Task<long?> GetIdByNumero(string numero);
        Task<Cuenta?> Get(string numero);
        Task<Cuenta?> Get(long IdCuenta);
        IEnumerable<CuentaInfoDto> GetAllDtos();
        bool Exists(long IdCuenta, string Numero);
        bool Exists(string Numero);
    }
}
