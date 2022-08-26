using PRUEBA.BACKEND.DOMAIN.DTOs;
using PRUEBA.BACKEND.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.Interfaces
{
    public interface IMovimientoRepositorio : IGenericRepository<Movimiento>
    {
        IEnumerable<MovimientoInfoDto> Get(EstadoCuentaRequestDto Model);
        decimal GetSaldo(long IdCuenta);
    }
}
