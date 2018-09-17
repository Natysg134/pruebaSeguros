using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Seguros.Models
{
    public class Seguro
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Cubrimiento { get; set; }
        public decimal Cobertura { get; set; }
        public DateTime FechaInicio { get; set; }
        public int Meses { get; set; }
        public decimal Precio { get; set; }
        public int Riesgo { get; set; }
        public string ClienteAsociado { get; set; }
    }
}