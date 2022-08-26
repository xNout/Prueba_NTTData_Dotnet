using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.DTOs
{
    public record CuentaInfoDto
    {
        public long IdCuenta { get; set; }
        public long IdCliente { get; set; }
        public string Cliente { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
    }
}
