using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.ViewModels.Livro
{
    public class LivroIndexViewModel
    {
        public int IdLivro { get; set; }

        [Display(Name = "Nome do livro")]
        public string NomeLivro { get; set; }

        [Display(Name = "Nome da coleção")]
        public string NomeColecao { get; set; }
    }
}