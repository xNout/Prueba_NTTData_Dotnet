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
    public class ClientesAppService : IClientesAppService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientesAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<CreatedClientResponseAppDto> GetAll()
        {
            return unitOfWork.clienteRepositorio.GetAllDtos();
        }
        public async Task Eliminar(long id)
        {
            try
            {
                await unitOfWork.BeginTransaction();

                Cliente? cliente = unitOfWork.clienteRepositorio.Get(id);
                if (cliente is null)
                    throw new ValidacionException($"No existe el cliente con id: {id}");

                Persona? persona = unitOfWork.personaRepositorio.Get((long)cliente.IdPersona);
                unitOfWork.clienteRepositorio.Remove(cliente);
                unitOfWork.personaRepositorio.Remove(persona);

                await unitOfWork.SaveChanges();
                await unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransaction();
                throw;
            }
        }
        public async Task Actualizar(long id, ClientRequestAppDto Model)
        {
            try
            {
                await unitOfWork.BeginTransaction();

                Cliente? cliente = unitOfWork.clienteRepositorio.Get(id);
                if (cliente is null)
                    throw new ValidacionException($"No existe el cliente con id: {id}");

                Persona? persona = unitOfWork.personaRepositorio.Get((long)cliente.IdPersona);
                persona.Nombre = Model.Nombres;
                persona.Genero = Model.Genero;
                persona.Direccion = Model.Direccion;
                persona.Edad = Model.Edad;
                persona.Identificacion = Model.Identificacion;
                persona.Telefono = Model.Telefono;
                unitOfWork.personaRepositorio.Update(persona);

                cliente.Contrasena = Model.Contrasena;
                unitOfWork.clienteRepositorio.Update(cliente);

                await unitOfWork.SaveChanges();
                await unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<CreatedClientResponseAppDto> Crear(ClientRequestAppDto Model)
        {
            if (unitOfWork.clienteRepositorio.ExistsByNombre(Model.Nombres))
                throw new ValidacionException($"Ya existe un cliente con el nombre: {Model.Nombres}");

            try
            {
                await unitOfWork.BeginTransaction();

                Persona persona = new()
                {
                    Nombre = Model.Nombres,
                    Genero = Model.Genero,
                    Direccion = Model.Direccion,
                    Edad = Model.Edad,
                    Identificacion = Model.Identificacion,
                    Telefono = Model.Telefono
                };
                await unitOfWork.personaRepositorio.AddAsync(persona);
                await unitOfWork.SaveChanges();

                Cliente cliente = new()
                {
                    IdPersona = persona.IdPersona,
                    Contrasena = Model.Contrasena,
                    Estado = true
                };

                await unitOfWork.clienteRepositorio.AddAsync(cliente);
                await unitOfWork.SaveChanges();

                await unitOfWork.CommitTransaction();

                return new CreatedClientResponseAppDto
                {
                    IdCliente = cliente.IdCliente,
                    Nombres = persona.Nombre,
                    Genero = persona.Genero,
                    Direccion = persona.Direccion,
                    Edad = persona.Edad,
                    Identificacion = persona.Identificacion,
                    Telefono = persona.Telefono,
                    Contrasena = cliente.Contrasena,
                    Estado = cliente.Estado
                };
            }
            catch(Exception ex)
            {
                await unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}
