using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.ViewModels.Colecao
{
    public class ColecaoIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome da Coleção")]
        public string Nome { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Ano de Lançamento")]
        public int AnoLancamento { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Editora")]
        public string Editora { get; set; }

    }
}