using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Livros.Dominio
{
    public class Livro
    {
        public long IdLivro { get; set; }

        public string NomeLivro { get; set; }

        public virtual Colecao Colecao {get; set;}

        public int IdColecao { get; set; }
    }
}
