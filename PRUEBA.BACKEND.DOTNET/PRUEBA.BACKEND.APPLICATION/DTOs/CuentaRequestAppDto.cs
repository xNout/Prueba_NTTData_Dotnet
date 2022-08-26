using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.DTOs
{
    public record CuentaRequestAppDto
    {
        public long IdCliente { get; set; }
        public string Numero { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
    }
}
