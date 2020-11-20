using Biblioteca.Livros.Dados.Entity.Context;
using Biblioteca.Livros.Dominio;
using Biblioteca.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Biblioteca.Livros.Repositorios.Entity
{
    public class LivrosRepositorio : RepositorioGenericoEntity<Livro, long>
    {
        public LivrosRepositorio(LivroDbContext contexto)
          : base(contexto)
        {

        }
        public override List<Livro> Selecionar()
        {
            return _contexto.Set<Livro>().Include(p => p.Colecao).ToList();
        }

        public override Livro SelecionarPorId(long id)
        {
            return _contexto.Set<Livro>().Include(p => p.Colecao)
                .SingleOrDefault(f => f.IdLivro == id);
        }
    }
}
