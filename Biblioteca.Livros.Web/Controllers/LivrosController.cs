using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Biblioteca.Livros.Dados.Entity.Context;
using Biblioteca.Livros.Dominio;
using Biblioteca.Livros.Repositorios.Comum;
using Biblioteca.Livros.Repositorios.Entity;
using Biblioteca.Livros.Web.ViewModels.Colecao;
using Biblioteca.Livros.Web.ViewModels.Livro;

namespace Biblioteca.Livros.Web.Controllers
{
    public class LivrosController : Controller
    {
        private IRepositorioGenerico<Livro, long>
           repositorioLivros = new LivrosRepositorio(new LivroDbContext());

        private IRepositorioGenerico<Colecao, int>
            repositorioColecoes = new ColecoesRepositorio(new LivroDbContext());

        // GET: Livros
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Livro>, List<LivroIndexViewModel>>(repositorioLivros.Selecionar()));
        }

        // GET: Livros/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = repositorioLivros.SelecionarPorId(id.Value);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Livro, LivroIndexViewModel>(livro));
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            List<ColecaoIndexViewModel> colecoes = Mapper.Map<List<Colecao>,
               List<ColecaoIndexViewModel>>(repositorioColecoes.Selecionar());

            SelectList dropDownColecoes = new SelectList(colecoes, "Id", "Nome");
            ViewBag.DropDownColecoes = dropDownColecoes;

            return View();
        }

        // POST: Livros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLivro,NomeLivro,IdColecao")] LivroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Livro livro = Mapper.Map<LivroViewModel, Livro>(viewModel);
                repositorioLivros.Inserir(livro);
                return RedirectToAction("Index");
            }
            List<ColecaoIndexViewModel> colecoes = Mapper.Map<List<Colecao>,
               List<ColecaoIndexViewModel>>(repositorioColecoes.Selecionar());

            SelectList dropDownColecoes = new SelectList(colecoes, "Id", "Nome");
            ViewBag.DropDownColecoes = dropDownColecoes;

            return View(viewModel);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = repositorioLivros.SelecionarPorId(id.Value);
            if (livro == null)
            {
                return HttpNotFound();
            }
            List<ColecaoIndexViewModel> colecoes = Mapper.Map<List<Colecao>,
                List<ColecaoIndexViewModel>>(repositorioColecoes.Selecionar());

            SelectList dropDownColecoes = new SelectList(colecoes, "Id", "Nome");
            ViewBag.DropDownColecoes = dropDownColecoes;

            return View(Mapper.Map<Livro, LivroViewModel>(livro));
        }

        // POST: Livros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLivro,NomeLivro,IdColecao")] LivroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Livro livro = Mapper.Map<LivroViewModel, Livro>(viewModel);
                repositorioLivros.Alterar(livro);
                return RedirectToAction("Index");
            }
            List<ColecaoIndexViewModel> colecoes = Mapper.Map<List<Colecao>,
                List<ColecaoIndexViewModel>>(repositorioColecoes.Selecionar());

            SelectList dropDownColecoes = new SelectList(colecoes, "Id", "Nome");
            ViewBag.DropDownColecoes = dropDownColecoes;

            return View(viewModel);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = repositorioLivros.SelecionarPorId(id.Value);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Livro, LivroIndexViewModel>(livro));
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioLivros.ExcluirPorId(id);
            return RedirectToAction("Index");
        }


    }
}
