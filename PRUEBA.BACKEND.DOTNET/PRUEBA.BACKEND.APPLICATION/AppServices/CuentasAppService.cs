using PRUEBA.BACKEND.APPLICATION.CustomExceptions;
using PRUEBA.BACKEND.APPLICATION.DTOs;
using PRUEBA.BACKEND.APPLICATION.Interfaces;
using PRUEBA.BACKEND.DOMAIN.DTOs;
using PRUEBA.BACKEND.DOMAIN.Entities;
using PRUEBA.BACKEND.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.AppServices
{
    public class CuentasAppService : ICuentasAppService
    {
        private readonly IUnitOfWork unitOfWork;

        public CuentasAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<CuentaInfoDto> GetAllDtos()
        {
            return unitOfWork.cuentaRepositorio.GetAllDtos();
        }
        public async Task Actualizar(long IdCuenta, CuentaRequestAppDto Model)
        {
            try
            {
                await unitOfWork.BeginTransaction();

                if (!unitOfWork.clienteRepositorio.Exists(Model.IdCliente))
                    throw new ValidacionException($"No existe el cliente con el id: {Model.IdCliente}");

                // Se verifica si existe una cuenta con el mismo numero pero diferente ID
                if (unitOfWork.cuentaRepositorio.Exists(IdCuenta, Model.Numero))
                    throw new ValidacionException($"Ya existe una cuenta registrada con el numero: {Model.Numero}");

                Cuenta? cuenta = await unitOfWork.cuentaRepositorio.Get(IdCuenta);
                if (cuenta is null)
                    throw new ValidacionException($"No existe la cuenta cuenta con id: {IdCuenta}");

                cuenta.IdCliente = Model.IdCliente;
                cuenta.Numero = Model.Numero;
                cuenta.SaldoInicial = Model.SaldoInicial;
                cuenta.Tipo = Model.Tipo;

                unitOfWork.cuentaRepositorio.Update(cuenta);

                await unitOfWork.SaveChanges();
                await unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransaction();
                throw;
            }
        }
        public async Task<Cuenta> Crear(CuentaRequestAppDto Model)
        {
            try
            {
                await unitOfWork.BeginTransaction();

                if (!unitOfWork.clienteRepositorio.Exists(Model.IdCliente))
                    throw new ValidacionException($"No existe el cliente con el id: {Model.IdCliente}");

                if (unitOfWork.cuentaRepositorio.Exists(Model.Numero))
                    throw new ValidacionException($"Ya existe una cuenta registrada con el numero: {Model.Numero}");

                Cuenta cuenta = new()
                {
                    IdCliente = Model.IdCliente,
                    Numero = Model.Numero,
                    SaldoInicial = Model.SaldoInicial,
                    Tipo = Model.Tipo,
                    Estado = true
                };
                await unitOfWork.cuentaRepositorio.AddAsync(cuenta);
                await unitOfWork.SaveChanges();

                await unitOfWork.CommitTransaction();

                return cuenta;
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}
