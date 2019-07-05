using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutosDAO dao;
        public ProdutoController()
        {
            dao = new ProdutosDAO();
        }

        // GET: Produto
        public ActionResult Index()
        {
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            dao.Adiciona(produto);
            return RedirectToAction("Index");
        }
    }
}