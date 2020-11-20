using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.Annotations
{
    public class EditoraAttribute : ValidationAttribute

    {
        public override bool IsValid(object value)
        {
            return value.ToString().Contains("Unipam");
        }
    }
}