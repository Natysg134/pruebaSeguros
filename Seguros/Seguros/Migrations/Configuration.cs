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
                new Seguro() { Id = 1, Nombre = "Seguro Prueba1", Cubrimiento = "Terremoto", Cobertura = 25, FechaInicio = Convert.ToDateTime("05 / 29 / 2015"), Meses = 12, Precio = 2000, TipoRiesgo = "Medio" },
                new Seguro() { Id = 2, Nombre = "Seguro Prueba2", Cubrimiento = "Incendio", Cobertura = 30, FechaInicio = Convert.ToDateTime("06 / 30 / 2016"), Meses = 3, Precio = 2400, TipoRiesgo = "Bajo"}              
                );

            context.Usuarios.AddOrUpdate(U => U.Id,
                new Usuario() { NombreUsuario = "Usuario1", Clave = "123456" }
                );
        }
    }
}
