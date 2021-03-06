﻿using Biblioteca.Livros.Web.Filtros;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Livros.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogActionFilter());
        }
    }
}
