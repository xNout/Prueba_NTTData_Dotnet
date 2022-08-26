using System;
using System.Collections.Generic;

namespace PRUEBA.BACKEND.DOMAIN.Entities
{
    public class Cuenta
    {
        public long IdCuenta { get; set; }
        public long? IdCliente { get; set; }
        public string Numero { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
