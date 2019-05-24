namespace SIS_ISENTREGA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriz",
                c => new
                    {
                        OidMatriz = c.Int(nullable: false, identity: true),
                        NomeMatriz = c.String(maxLength: 18),
                        DataCadastro = c.DateTime(nullable: false),
                        CEP = c.String(),
                    })
                .PrimaryKey(t => t.OidMatriz);
            
            CreateTable(
                "dbo.Ponto",
                c => new
                    {
                        OidPonto = c.Int(nullable: false, identity: true),
                        OidMatriz = c.Int(nullable: false),
                        NomeMatriz = c.String(maxLength: 18),
                        DataCadastro = c.DateTime(nullable: false),
                        CEP = c.String(),
                    })
                .PrimaryKey(t => t.OidPonto)
                .ForeignKey("dbo.Matriz", t => t.OidMatriz)
                .Index(t => t.OidMatriz);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        OidUsuario = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(maxLength: 100),
                        DataCadastro = c.DateTime(nullable: false),
                        FlAtivo = c.Boolean(nullable: false),
                        Token = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OidUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ponto", "OidMatriz", "dbo.Matriz");
            DropIndex("dbo.Ponto", new[] { "OidMatriz" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Ponto");
            DropTable("dbo.Matriz");
        }
    }
}
