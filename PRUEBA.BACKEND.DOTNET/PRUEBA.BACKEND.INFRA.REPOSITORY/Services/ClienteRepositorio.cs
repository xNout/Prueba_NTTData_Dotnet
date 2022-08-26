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
    public class ClienteRepositorio : GenericRepository<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(DBContexto context) : base(context)
        {
        }
        public IEnumerable<CreatedClientResponseAppDto> GetAllDtos()
        {
            return (from persona in context.Personas.AsQueryable()
             join cliente in context.Clientes.AsQueryable()
             on persona.IdPersona equals cliente.IdPersona
             select new CreatedClientResponseAppDto
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
             });
        }
        public Cliente? Get(long IdCliente)
        {
            return context.Clientes.FirstOrDefault(x => x.IdCliente == IdCliente && x.Estado);
        }
        public bool Exists(long IdCliente)
        {
            return context.Clientes.Any(x => x.IdCliente == IdCliente);
        }
        public bool ExistsByNombre(string Nombre)
        {
            return context.Personas.Any(x => x.Nombre == Nombre);
        }
    }
}
