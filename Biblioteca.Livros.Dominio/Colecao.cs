using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Livros.Dominio
{
    public class Colecao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public int AnoLancamento { get; set; }

        public string Descricao { get; set; }

        public string Editora { get; set; }

        public virtual List<Livro> Livros { get; set; }

    }
}
