namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Seguros.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Seguros.Models.SegurosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Seguros.Models.SegurosContext context)
        {
            context.Seguros.AddOrUpdate(X => X.Id,
                new Seguro() { Id = 1, Nombre = "Seguro Prueba1", Cubrimiento = "Terremoto", Cobertura = 25, FechaInicio = Convert.ToDateTime("05 / 29 / 2015"), Meses = 12, Precio = 2000, TipoRiesgo = "Medio"}
                );
        }
    }
}
