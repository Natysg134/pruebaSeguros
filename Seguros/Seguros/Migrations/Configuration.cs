namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Seguros.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Seguros.DAL.SegurosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Seguros.DAL.SegurosContext context)
        {

            context.TipoRiesgos.AddOrUpdate(T => T.Id,
                new TipoRiesgo() { Id=1, Riesgo = "Bajo"},
                new TipoRiesgo() { Id=2, Riesgo = "Medio" },
                new TipoRiesgo() { Id=3, Riesgo = "Medio-Alto" },
                new TipoRiesgo() { Id=4, Riesgo = "Alto" }
                );

            context.Clientes.AddOrUpdate(C => C.Identificacion,
                new Cliente() { Nombre = "Juan Lopez", Identificacion = "603450567"},
                new Cliente() { Nombre = "Carlos Mora", Identificacion = "506740987" },
                new Cliente() { Nombre = "Luis Gomez", Identificacion = "102360643" }
                );

            context.Seguros.AddOrUpdate(S => S.Id,
                new Seguro() {
                    Nombre = "Seguro Prueba1",
                    Descripcion = "Este es un Seguro de Prueba",
                    Cubrimiento = "Terremoto",
                    Cobertura = 25,
                    FechaInicio = Convert.ToDateTime("05 / 29 / 2015"),
                    Meses = 12,
                    Precio = 2000,
                    Riesgo =  context.TipoRiesgos.FirstOrDefault(x => x.Riesgo == "Bajo").Id ,
                    ClienteAsociado = context.Clientes.FirstOrDefault(x => x.Identificacion == "506740987").Identificacion 
                },

                new Seguro() {
                    Nombre = "Seguro Prueba2",
                    Descripcion = "Este es un Seguro de Prueba",
                    Cubrimiento = "Incendio",
                    Cobertura = 30,
                    FechaInicio = Convert.ToDateTime("06 / 30 / 2016"),
                    Meses = 3,
                    Precio = 2400,
                    Riesgo = context.TipoRiesgos.FirstOrDefault(x => x.Riesgo == "Alto").Id ,
                    ClienteAsociado = context.Clientes.FirstOrDefault(x => x.Identificacion == "603450567").Identificacion 
                }              
                );

            context.Usuarios.AddOrUpdate(U => U.Id,
                new Usuario() { NombreUsuario = "Usuario1", Clave = "123456" }
                );
        }


    }
}
