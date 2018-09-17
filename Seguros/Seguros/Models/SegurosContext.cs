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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoRiesgo> TipoRiesgos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());
        }
    }
}