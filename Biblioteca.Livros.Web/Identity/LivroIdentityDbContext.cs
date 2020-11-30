using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Livros.Web.Identity
{
    public class LivroIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public LivroIdentityDbContext()
            : base("LivroDbContext")
        {

        }
    }
}