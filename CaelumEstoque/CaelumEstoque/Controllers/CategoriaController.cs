using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriasDAO dao;

        public CategoriaController()
        {
            dao = new CategoriasDAO();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Adicionar(CategoriaDoProduto categoria)
        {
            dao.Adiciona(categoria);
            return RedirectToAction("Index");
        }
    }
}