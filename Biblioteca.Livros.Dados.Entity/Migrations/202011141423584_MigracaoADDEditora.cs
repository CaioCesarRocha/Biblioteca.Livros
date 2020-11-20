namespace Biblioteca.Livros.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoADDEditora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colecao", "Editora", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Colecao", "Editora");
        }
    }
}
