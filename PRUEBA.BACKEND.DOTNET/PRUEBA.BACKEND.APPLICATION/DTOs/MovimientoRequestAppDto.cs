using PRUEBA.BACKEND.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.DTOs
{
    public record MovimientoRequestAppDto
    {
        public DateTime Fecha { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        [Required]
        public TipoMovimiento Tipo { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Valor { get; set; }
    }
}
