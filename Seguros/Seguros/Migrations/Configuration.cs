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

            context.TipoRiesgos.AddOrUpdate(T => T.Id,
                new TipoRiesgo() { Id = 1, Riesgo = "Bajo" },
                new TipoRiesgo() { Id = 2, Riesgo = "Medio" },
                new TipoRiesgo() { Id = 3, Riesgo = "Medio-Alto" },
                new TipoRiesgo() { Id = 4, Riesgo = "Alto" }
                );

            context.Clientes.AddOrUpdate(C => C.Identificacion,
                new Cliente() { Nombre = "Juan Lopez", Identificacion = "603450567" },
                new Cliente() { Nombre = "Carlos Mora", Identificacion = "506740987" },
                new Cliente() { Nombre = "Luis Gomez", Identificacion = "102360643" }
                );

            context.Seguros.AddOrUpdate(S => S.Id,
                new Seguro()
                {
                    Nombre = "Seguro Prueba1",
                    Descripcion = "Este es un Seguro de Prueba",
                    Cubrimiento = "Terremoto",
                    Cobertura = 25,
                    FechaInicio = Convert.ToDateTime("05 / 29 / 2015"),
                    Meses = 12,
                    Precio = 2000,
                    Riesgo = 2,
                    ClienteAsociado =  "506740987"
                },

                new Seguro()
                {
                    Nombre = "Seguro Prueba2",
                    Descripcion = "Este es un Seguro de Prueba",
                    Cubrimiento = "Incendio",
                    Cobertura = 30,
                    FechaInicio = Convert.ToDateTime("06 / 30 / 2016"),
                    Meses = 3,
                    Precio = 2400,
                    Riesgo = 4,
                    ClienteAsociado = "603450567"
                }
                );

            context.Usuarios.AddOrUpdate(U => U.Id,
                new Usuario() { NombreUsuario = "Usuario1", Clave = "123456" }
                );
        }


    }
}