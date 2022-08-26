﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.DTOs
{
    public record MovimientoInfoDto
    {
        public string Fecha { get; set; }
        public string Cliente { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
