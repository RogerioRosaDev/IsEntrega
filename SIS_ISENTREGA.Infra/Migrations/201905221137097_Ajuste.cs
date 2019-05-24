namespace SIS_ISENTREGA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.Usuario", "Senha", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Senha");
            DropColumn("dbo.Usuario", "Email");
        }
    }
}
