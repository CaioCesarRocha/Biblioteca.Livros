namespace Biblioteca.Livros.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLivro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        IdLivro = c.Long(nullable: false, identity: true),
                        NomeLivro = c.String(nullable: false, maxLength: 100),
                        IdColecao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLivro)
                .ForeignKey("dbo.Colecao", t => t.IdColecao, cascadeDelete: true)
                .Index(t => t.IdColecao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "IdColecao", "dbo.Colecao");
            DropIndex("dbo.Livro", new[] { "IdColecao" });
            DropTable("dbo.Livro");
        }
    }
}
