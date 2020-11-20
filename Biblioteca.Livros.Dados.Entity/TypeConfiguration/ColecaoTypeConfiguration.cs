using Biblioteca.Livros.Dominio;
using Biblioteca.Livros.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Livros.Dados.Entity.TypeConfiguration
{
    class ColecaoTypeConfiguration : BibliotecaEntityAbstractConfig<Colecao>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade");

            Property(p => p.AnoLancamento)
                .IsRequired()
                .HasColumnName("Ano de Lancamento");

            Property(p => p.Descricao)
                .IsOptional()
                .HasMaxLength(1000)
                .HasColumnName("Descricao");

            Property(p => p.Editora)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Editora");


        }

        protected override void ConfigurarChaveEstrangeira()
        {
            
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Colecao");
        }
    }
}
