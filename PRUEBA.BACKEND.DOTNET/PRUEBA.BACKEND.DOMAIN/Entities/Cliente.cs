using System;
using System.Collections.Generic;

namespace PRUEBA.BACKEND.DOMAIN.Entities
{
    public class Cliente
    {
        public long IdCliente { get; set; }
        public long? IdPersona { get; set; }
        public string Contrasena { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
