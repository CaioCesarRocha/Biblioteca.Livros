using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.ViewModels.Livro
{
    public class LivroViewModel
    {
        [Required(ErrorMessage = "O IdLivro é obrigatório")]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "O nome do livro é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do livrro deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome do livro")]
        public string NomeLivro { get; set; }

        [Required(ErrorMessage = "Selecione uma coleção")]
        [Display(Name = "Nome da colecao")]
        public int IdColecao { get; set; }
    }
}