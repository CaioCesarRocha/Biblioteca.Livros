using Biblioteca.Livros.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.ViewModels.Colecao
{
    public class ColecaoViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome da Coleção")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Pelo menos uma unidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório")]
        [Display(Name = "Ano de Lançamento")]
        public int AnoLancamento { get; set; }

        [MaxLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A editora é obrigatório")]
        [MaxLength(100, ErrorMessage = "A Editora deve ter no máximo 100 caracteres")]
        [Editora(ErrorMessage ="Editora deve ser a Unipam")]
        [Display(Name = "Editora")]
        public string Editora { get; set; }
    }
}