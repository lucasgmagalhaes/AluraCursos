using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using LojaWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class CategoriasController : Controller
    {
        //
        // GET: /Categorias/

        private readonly CategoriasDAO categoriaDAO;
        public CategoriasController()
        {
            this.categoriaDAO = new CategoriasDAO(NHibernateHelper.AbreSession());
        }

        public ActionResult Index()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Categoria categoria)
        {
            this.categoriaDAO.Adiciona(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {

            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Categoria categoria = new Categoria();
            return View(categoria);
        }

        public ActionResult Atualiza(Categoria categoria)
        {
            return RedirectToAction("Index");
        }

        public ActionResult CategoriasEProdutos()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult BuscaPorNome(string nome)
        {
            ViewBag.Nome = nome;

            IList<Categoria> categorias = this.categoriaDAO.BuscaPorNome(nome);
            return View(categorias);
        }

        public ActionResult NumeroDeProdutosPorCategoria()
        {
            IList<ProdutosPorCategoria> produtosPorCategoria = this.categoriaDAO.ListaNumeroDeProdutosPorCategoria();
            return View(produtosPorCategoria);
        }
    }
}
