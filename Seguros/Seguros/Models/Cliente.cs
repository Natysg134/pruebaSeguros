using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Seguros.Models
{
    public class Cliente
    {

        public string Nombre { get; set; }
        [Key]
        public string Identificacion { get; set; }
    }
}