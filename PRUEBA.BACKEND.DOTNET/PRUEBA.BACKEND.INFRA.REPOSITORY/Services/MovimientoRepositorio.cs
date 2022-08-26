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
    public class MovimientoRepositorio : GenericRepository<Movimiento>, IMovimientoRepositorio
    {
        public MovimientoRepositorio(DBContexto context) : base(context)
        {
        }


        public decimal GetSaldo(long IdCuenta)
        {
            if (!context.Movimientos.Any(x => x.IdCuenta == IdCuenta))
                return context.Cuentas
                    .Where(x => x.IdCuenta == IdCuenta)
                    .Select(x => x.SaldoInicial)
                    .FirstOrDefault();

            return context.Movimientos
                .Where(x => x.IdCuenta == IdCuenta)
                .OrderByDescending(x => x.Fecha)
                .Select(x => x.Saldo)
                .FirstOrDefault();
        }

        public IEnumerable<MovimientoInfoDto> Get(EstadoCuentaRequestDto Model)
        {

            return (
                from persona in context.Personas.AsQueryable()
                join cliente in context.Clientes.AsQueryable()
                on persona.IdPersona equals cliente.IdPersona
                join cuenta in context.Cuentas.AsQueryable()
                on cliente.IdCliente equals cuenta.IdCliente
                join movimiento in context.Movimientos.AsQueryable()
                on cuenta.IdCuenta equals movimiento.IdCuenta

                where cliente.IdCliente == Model.IdCliente
                && movimiento.Fecha >= Model.Desde && movimiento.Fecha <= Model.Hasta
                orderby movimiento.Fecha descending
                select new MovimientoInfoDto
                {
                    Fecha = movimiento.Fecha.ToString("dd/MM/yyyy"),
                    Cliente = persona.Nombre,
                    Estado = cuenta.Estado,
                    Movimiento = movimiento.Valor,
                    NumeroCuenta = cuenta.Numero,
                    SaldoDisponible = movimiento.Saldo,
                    SaldoInicial = cuenta.SaldoInicial,
                    Tipo = movimiento.TipoMovimiento
                });
        }
    }
}
