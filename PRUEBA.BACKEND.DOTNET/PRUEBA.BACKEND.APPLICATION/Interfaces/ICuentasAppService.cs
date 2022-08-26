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
    public interface ICuentasAppService
    {
        Task Actualizar(long IdCuenta, CuentaRequestAppDto Model);
        IEnumerable<CuentaInfoDto> GetAllDtos();
        Task<Cuenta> Crear(CuentaRequestAppDto Model);
    }
}
