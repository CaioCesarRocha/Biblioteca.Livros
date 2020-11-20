using AutoMapper;
using Biblioteca.Livros.Dominio;
using Biblioteca.Livros.Web.ViewModels.Colecao;
using Biblioteca.Livros.Web.ViewModels.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ColecaoViewModel, Colecao>();
            Mapper.CreateMap<LivroViewModel, Livro>();
        }
    }
}