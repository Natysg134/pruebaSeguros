namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Identificacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoRiesgoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Riesgo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Seguroes", "ClienteAsociado_Id", c => c.Int());
            AddColumn("dbo.Seguroes", "Riesgo_Id", c => c.Int());
            CreateIndex("dbo.Seguroes", "ClienteAsociado_Id");
            CreateIndex("dbo.Seguroes", "Riesgo_Id");
            AddForeignKey("dbo.Seguroes", "ClienteAsociado_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Seguroes", "Riesgo_Id", "dbo.TipoRiesgoes", "Id");
            DropColumn("dbo.Seguroes", "TipoRiesgo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seguroes", "TipoRiesgo", c => c.String());
            DropForeignKey("dbo.Seguroes", "Riesgo_Id", "dbo.TipoRiesgoes");
            DropForeignKey("dbo.Seguroes", "ClienteAsociado_Id", "dbo.Clientes");
            DropIndex("dbo.Seguroes", new[] { "Riesgo_Id" });
            DropIndex("dbo.Seguroes", new[] { "ClienteAsociado_Id" });
            DropColumn("dbo.Seguroes", "Riesgo_Id");
            DropColumn("dbo.Seguroes", "ClienteAsociado_Id");
            DropTable("dbo.TipoRiesgoes");
            DropTable("dbo.Clientes");
        }
    }
}
