using PRUEBA.BACKEND.APPLICATION.DTOs;
using PRUEBA.BACKEND.DOMAIN.DTOs;
using PRUEBA.BACKEND.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.Interfaces
{
    public interface IMovimientosAppService
    {
        IEnumerable<MovimientoInfoDto> Get(long IdCliente, string Desde, string Hasta);
        Task<Movimiento> Crear(MovimientoRequestAppDto Model);
    }
}
