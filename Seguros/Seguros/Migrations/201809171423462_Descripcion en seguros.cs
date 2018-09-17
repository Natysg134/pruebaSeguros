namespace Seguros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Descripcionenseguros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seguroes", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seguroes", "Descripcion");
        }
    }
}
