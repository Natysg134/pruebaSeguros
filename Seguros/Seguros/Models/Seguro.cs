using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguros.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cubrimiento { get; set; }
        public DateTime FechaInicio { get; set; }
        public int Meses { get; set; }
        public decimal Precio { get; set; }
        public string TipoRiesgo { get; set; }
    }
}