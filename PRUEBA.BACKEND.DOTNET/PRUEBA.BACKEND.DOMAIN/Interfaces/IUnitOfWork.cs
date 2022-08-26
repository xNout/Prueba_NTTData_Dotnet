using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task SaveChanges();
        IPersonaRepositorio personaRepositorio { get; }
        IClienteRepositorio clienteRepositorio { get; }
        ICuentaRepositorio cuentaRepositorio { get; }
        IMovimientoRepositorio movimientoRepositorio { get; }
    }
}
