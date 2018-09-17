namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkseguros : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seguroes", "ClienteAsociado_Identificacion", "dbo.Clientes");
            DropForeignKey("dbo.Seguroes", "Riesgo_Id", "dbo.TipoRiesgoes");
            DropIndex("dbo.Seguroes", new[] { "ClienteAsociado_Identificacion" });
            DropIndex("dbo.Seguroes", new[] { "Riesgo_Id" });
            AddColumn("dbo.Seguroes", "Riesgo", c => c.Int(nullable: false));
            AddColumn("dbo.Seguroes", "ClienteAsociado", c => c.String());
            DropColumn("dbo.Seguroes", "ClienteAsociado_Identificacion");
            DropColumn("dbo.Seguroes", "Riesgo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seguroes", "Riesgo_Id", c => c.Int());
            AddColumn("dbo.Seguroes", "ClienteAsociado_Identificacion", c => c.String(maxLength: 128));
            DropColumn("dbo.Seguroes", "ClienteAsociado");
            DropColumn("dbo.Seguroes", "Riesgo");
            CreateIndex("dbo.Seguroes", "Riesgo_Id");
            CreateIndex("dbo.Seguroes", "ClienteAsociado_Identificacion");
            AddForeignKey("dbo.Seguroes", "Riesgo_Id", "dbo.TipoRiesgoes", "Id");
            AddForeignKey("dbo.Seguroes", "ClienteAsociado_Identificacion", "dbo.Clientes", "Identificacion");
        }
    }
}
