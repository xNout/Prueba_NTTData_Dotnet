using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.BACKEND.APPLICATION.DTOs
{
    public record ClientRequestAppDto
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Identificacion { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Contrasena { get; set; }
    }
}
