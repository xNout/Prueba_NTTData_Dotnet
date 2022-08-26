using PRUEBA.BACKEND.APPLICATION.DTOs;
using PRUEBA.BACKEND.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.Interfaces
{
    public interface IClientesAppService
    {
        Task Eliminar(long id);
        IEnumerable<CreatedClientResponseAppDto> GetAll();
        Task Actualizar(long id, ClientRequestAppDto Model);
        Task<CreatedClientResponseAppDto> Crear(ClientRequestAppDto Model);
    }
}
