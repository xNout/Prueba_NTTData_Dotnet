using PRUEBA.BACKEND.APPLICATION.CustomExceptions;
using PRUEBA.BACKEND.APPLICATION.DTOs;
using PRUEBA.BACKEND.APPLICATION.Interfaces;
using PRUEBA.BACKEND.DOMAIN.DTOs;
using PRUEBA.BACKEND.DOMAIN.Entities;
using PRUEBA.BACKEND.DOMAIN.Enums;
using PRUEBA.BACKEND.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.AppServices
{
    public class MovimientosAppService : IMovimientosAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public MovimientosAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<MovimientoInfoDto> Get(long IdCliente, string Desde, string Hasta)
        {
            Regex regExp = new(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$");
            if(!regExp.IsMatch(Desde))
                throw new ValidacionException($"Formato de la fecha Desde no es el correcto: YYYY-MM-DD");

            if (!regExp.IsMatch(Hasta))
                throw new ValidacionException($"Formato de la fecha Hasta no es el correcto: YYYY-MM-DD");

            EstadoCuentaRequestDto Model = new()
            {
                IdCliente = IdCliente,
                Desde = DateTime.ParseExact(Desde, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Hasta = DateTime.ParseExact(Hasta, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            return unitOfWork.movimientoRepositorio.Get(Model);
        }
        public async Task<Movimiento> Crear(MovimientoRequestAppDto Model)
        {
            decimal SaldoRestante = 0;
            decimal _Valor = Model.Valor;

            try
            {
                await unitOfWork.BeginTransaction();

                long? IdCuenta = await unitOfWork.cuentaRepositorio.GetIdByNumero(Model.NumeroCuenta);
                if(IdCuenta is null)
                    throw new ValidacionException($"No existe la cuenta con el numero: {Model.NumeroCuenta}");

                decimal Saldo = unitOfWork.movimientoRepositorio.GetSaldo((long)IdCuenta);
                if (Model.Tipo is TipoMovimiento.DEBITO)
                {
                    if(Saldo == 0)
                        throw new ValidacionException("Saldo no disponible");

                    SaldoRestante = Saldo - Model.Valor;
                    if (SaldoRestante < 0)
                        throw new ValidacionException("Saldo insuficiente");

                    _Valor *= -1;
                }
                else
                {
                    SaldoRestante = Saldo + Model.Valor;
                }
                

                Movimiento movimiento = new()
                {
                    Fecha = Model.Fecha,
                    IdCuenta = IdCuenta,
                    Saldo = SaldoRestante,
                    Valor = _Valor,
                    TipoMovimiento = Model.Tipo is TipoMovimiento.DEBITO ? "DEBITO" : "CREDITO"
                };

                await unitOfWork.movimientoRepositorio.AddAsync(movimiento);

                await unitOfWork.SaveChanges();
                await unitOfWork.CommitTransaction();
                return movimiento;
            }
            catch(Exception ex)
            {
                await unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}
