namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Llaves : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seguroes", "ClienteAsociado_Id", "dbo.Clientes");
            DropIndex("dbo.Seguroes", new[] { "ClienteAsociado_Id" });
            RenameColumn(table: "dbo.Seguroes", name: "ClienteAsociado_Id", newName: "ClienteAsociado_Identificacion");
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Clientes", "Identificacion", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Seguroes", "ClienteAsociado_Identificacion", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Clientes", "Identificacion");
            CreateIndex("dbo.Seguroes", "ClienteAsociado_Identificacion");
            AddForeignKey("dbo.Seguroes", "ClienteAsociado_Identificacion", "dbo.Clientes", "Identificacion");
            DropColumn("dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Seguroes", "ClienteAsociado_Identificacion", "dbo.Clientes");
            DropIndex("dbo.Seguroes", new[] { "ClienteAsociado_Identificacion" });
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Seguroes", "ClienteAsociado_Identificacion", c => c.Int());
            AlterColumn("dbo.Clientes", "Identificacion", c => c.String());
            AddPrimaryKey("dbo.Clientes", "Id");
            RenameColumn(table: "dbo.Seguroes", name: "ClienteAsociado_Identificacion", newName: "ClienteAsociado_Id");
            CreateIndex("dbo.Seguroes", "ClienteAsociado_Id");
            AddForeignKey("dbo.Seguroes", "ClienteAsociado_Id", "dbo.Clientes", "Id");
        }
    }
}
