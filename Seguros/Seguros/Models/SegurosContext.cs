using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Seguros.Models
{
    public class SegurosContext : DbContext
    {
        public SegurosContext() 
        
            : base("name=SegurosContext")
        {
            //base.Configuration.ProxyCreationEnabled = false;
        }
        
        public DbSet<Seguro> Seguros { get; set; }
    }
}