namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seguroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cubrimiento = c.String(),
                        Cobertura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaInicio = c.DateTime(nullable: false),
                        Meses = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoRiesgo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seguroes");
        }
    }
}
