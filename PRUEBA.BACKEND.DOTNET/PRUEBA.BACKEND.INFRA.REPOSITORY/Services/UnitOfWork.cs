using Microsoft.EntityFrameworkCore.Storage;
using PRUEBA.BACKEND.DOMAIN.Interfaces;
using PRUEBA.BACKEND.INFRA.REPOSITORY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.INFRA.REPOSITORY.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContexto contexto;

        private IPersonaRepositorio? _personaRepositorio;
        private IClienteRepositorio? _clienteRepositorio;
        private ICuentaRepositorio? _cuentaRepositorio;
        private IMovimientoRepositorio? _movimientoRepositorio;
        private IDbContextTransaction? transaction;
        #region propiedades
        public IPersonaRepositorio personaRepositorio
        {
            get
            {
                if(_personaRepositorio is null)
                    _personaRepositorio = new PersonaRepositorio(contexto);
                
                return _personaRepositorio;
            }
        }
        public IClienteRepositorio clienteRepositorio
        {
            get
            {
                if (_clienteRepositorio is null)
                    _clienteRepositorio = new ClienteRepositorio(contexto);

                return _clienteRepositorio;
            }
        }
        public ICuentaRepositorio cuentaRepositorio
        {
            get
            {
                if (_cuentaRepositorio is null)
                    _cuentaRepositorio = new CuentaRepositorio(contexto);

                return _cuentaRepositorio;
            }
        }
        public IMovimientoRepositorio movimientoRepositorio
        {
            get
            {
                if (_movimientoRepositorio is null)
                    _movimientoRepositorio = new MovimientoRepositorio(contexto);

                return _movimientoRepositorio;
            }
        }
        #endregion
        public UnitOfWork(DBContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task BeginTransaction()
        {
            this.transaction = await contexto.Database.BeginTransactionAsync();
        }
        public async Task CommitTransaction()
        {
            if (transaction is null)
                throw new Exception("Primero debes inicializar una transaccion antes de realizar un commit");

            await transaction.CommitAsync();
        }
        public async Task RollbackTransaction()
        {
            if (transaction is null)
                throw new Exception("Primero debes inicializar una transaccion antes de realizar un rollback");

            await transaction.RollbackAsync();
            await transaction.DisposeAsync();
        }
        public async Task SaveChanges()
        {
            await contexto.SaveChangesAsync();
        }
        public void Dispose()
        {
            contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
