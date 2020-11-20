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
    public class ColecoesRepositorio : RepositorioGenericoEntity<Colecao, int>
    {
        public ColecoesRepositorio(LivroDbContext contexto)
           : base(contexto)
        {

        }
        public override List<Colecao> Selecionar()
        {
            return _contexto.Set<Colecao>().Include(p => p.Livros).ToList();
        }

        public override Colecao SelecionarPorId(int id)
        {
            return _contexto.Set<Colecao>().Include(p => p.Livros)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
