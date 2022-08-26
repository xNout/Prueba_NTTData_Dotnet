using Microsoft.EntityFrameworkCore;
using PRUEBA.BACKEND.DOMAIN.DTOs;
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
    public class CuentaRepositorio : GenericRepository<Cuenta>, ICuentaRepositorio
    {
        public CuentaRepositorio(DBContexto context) : base(context)
        {
        }

        public bool Exists(string Numero)
        {
            return context.Cuentas.Any(x => x.Numero == Numero);
        }
        public bool Exists(long IdCuenta, string Numero)
        {
            return context.Cuentas.Any(x => x.Numero == Numero && x.IdCuenta != IdCuenta);
        }
        public async Task<long?> GetIdByNumero(string numero)
        {
            return await context.Cuentas
                .Where(x => x.Numero == numero)
                .Select(x => x.IdCuenta)
                .FirstOrDefaultAsync();
        }
        public async Task<Cuenta?> Get(string numero)
        {
            return await context.Cuentas.FirstOrDefaultAsync(x => x.Numero == numero);
        }
        public async Task<Cuenta?> Get(long IdCuenta)
        {
            return await context.Cuentas.FirstOrDefaultAsync(x => x.IdCuenta == IdCuenta);
        }

        public IEnumerable<CuentaInfoDto> GetAllDtos()
        {
            return (
                from cuenta in context.Cuentas.AsQueryable()
                join cliente in context.Clientes.AsQueryable()
                on cuenta.IdCliente equals cliente.IdCliente
                join persona in context.Personas.AsQueryable()
                on cliente.IdPersona equals persona.IdPersona
                select new CuentaInfoDto
                {
                    IdCliente = cliente.IdCliente,
                    IdCuenta = cuenta.IdCuenta,
                    Cliente = persona.Nombre,
                    Numero = cuenta.Numero,
                    SaldoInicial = cuenta.SaldoInicial,
                    Tipo = cuenta.Tipo
                }
            );
        }
    }
}
