using Biblioteca.Livros.Dados.Entity.TypeConfiguration;
using Biblioteca.Livros.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Livros.Dados.Entity.Context
{
    public class LivroDbContext : DbContext
    {
        public DbSet<Colecao> Colecoes { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public LivroDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ColecaoTypeConfiguration());
            modelBuilder.Configurations.Add(new LivroTypeConfiguration());
        }
    }
}
