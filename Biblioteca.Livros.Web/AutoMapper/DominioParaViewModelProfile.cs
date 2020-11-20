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
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Colecao, ColecaoIndexViewModel>()
                .ForMember(p => p.Nome, opt =>
                {
                    opt.MapFrom(src =>
                    string.Format("{0} {1}", src.Nome, src.AnoLancamento.ToString())
                   );
                });
            Mapper.CreateMap<Colecao, ColecaoViewModel>();

            Mapper.CreateMap<Livro, LivroIndexViewModel>()
                .ForMember(p => p.NomeColecao, opt =>
                {
                    opt.MapFrom(src =>
                   src.Colecao.Nome
                   );
                }); ;
            Mapper.CreateMap<Livro, LivroViewModel>();
        }
    }
}