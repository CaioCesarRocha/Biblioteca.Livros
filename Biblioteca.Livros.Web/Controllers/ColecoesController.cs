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
using Biblioteca.Livros.Web.Filtros;
using Biblioteca.Livros.Web.ViewModels.Colecao;

namespace Biblioteca.Livros.Web.Controllers
{
    [Authorize]
    [LogActionFilter]
    
    public class ColecoesController : Controller
    {
        private IRepositorioGenerico<Colecao, int>
           repositorioColecoes = new ColecoesRepositorio(new LivroDbContext());

        // GET: Colecoes
        
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Colecao>, List<ColecaoIndexViewModel>>(repositorioColecoes.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Colecao> colecoes = repositorioColecoes
                .Selecionar()
                .Where(a => a.Nome.Contains(pesquisa)).ToList();

            List<ColecaoIndexViewModel> viewModels = Mapper
                .Map<List<Colecao>, List<ColecaoIndexViewModel>>(colecoes);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Colecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colecao colecao = repositorioColecoes.SelecionarPorId(id.Value);
            if (colecao == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Colecao, ColecaoIndexViewModel>(colecao));
        }

        // GET: Colecoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colecoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Quantidade,AnoLancamento,Descricao, Editora")] ColecaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Colecao colecao = Mapper.Map<ColecaoViewModel, Colecao>(viewModel);
                repositorioColecoes.Inserir(colecao);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Colecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colecao colecao = repositorioColecoes.SelecionarPorId(id.Value);
            if (colecao == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Colecao,ColecaoViewModel>(colecao));
        }

        // POST: Colecoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Quantidade,AnoLancamento,Descricao, Editora")] ColecaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Colecao colecao = Mapper.Map<ColecaoViewModel, Colecao>(viewModel);
                repositorioColecoes.Alterar(colecao);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Colecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colecao colecao = repositorioColecoes.SelecionarPorId(id.Value);
            if (colecao == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Colecao, ColecaoIndexViewModel>(colecao));
        }

        // POST: Colecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioColecoes.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

        
    }
}
