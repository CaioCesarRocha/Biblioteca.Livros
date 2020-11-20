using AutoMapper;
using Biblioteca.Livros.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.App_Start
{
    public static class AutoMapperConfig

    {
        public static void Configurar()
        {
            Mapper.AddProfile<DominioParaViewModelProfile>();
            Mapper.AddProfile<ViewModelParaDominioProfile>();
        }
    }
}