﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.DOMAIN.DTOs
{
    public record EstadoCuentaRequestDto
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public long IdCliente { get; set; }
    }
}
