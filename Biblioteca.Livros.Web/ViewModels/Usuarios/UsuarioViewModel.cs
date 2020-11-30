using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="O email é obrigatorio")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatoria")]
        [DataType(DataType.Password)]
        public string senha { get; set; }
    }
}