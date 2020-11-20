using Biblioteca.Livros.Dominio;
using Biblioteca.Livros.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Livros.Dados.Entity.TypeConfiguration
{
    class LivroTypeConfiguration : BibliotecaEntityAbstractConfig<Livro>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdLivro)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdLivro");

            Property(p => p.NomeLivro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NomeLivro");

            Property(p => p.IdColecao)
                .IsRequired()
                .HasColumnName("IdColecao");
        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(f => f.Colecao)
           .WithMany(a => a.Livros)
           .HasForeignKey(f => f.IdColecao);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.IdLivro);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Livro");
        }
    }
}
