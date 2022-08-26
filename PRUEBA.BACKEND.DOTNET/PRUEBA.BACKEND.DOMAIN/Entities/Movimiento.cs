using System;
using System.Collections.Generic;

namespace PRUEBA.BACKEND.DOMAIN.Entities
{
    public class Movimiento
    {
        public long IdMovimiento { get; set; }
        public long? IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}
