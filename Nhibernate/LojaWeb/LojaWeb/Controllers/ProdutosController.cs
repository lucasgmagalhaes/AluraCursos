﻿using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/

        private readonly ProdutosDAO produtoDAO;

        public ProdutosController()
        {
            this.produtoDAO = new ProdutosDAO(NHibernateHelper.AbreSession());
        }

        public ActionResult Index()
        {
            List<Produto> produtos = this.produtoDAO.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Produto produto)
        {
            produtoDAO.Adiciona(produto);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Produto p = produtoDAO.BuscaPorId(id);
            return View(p);
        }

        public ActionResult Atualiza(Produto produto)
        {
            return RedirectToAction("Index");
        }

        public ActionResult ProdutosComPrecoMinimo(double? preco)
        {
            IList<Produto> produtos = this.produtoDAO.ProdutosComPrecoMaiorDoQue(preco);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            IList<Produto> produtos = this.produtoDAO.ProdutosDaCategoria(nomeCategoria);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(double? preco, string nomeCategoria)
        {
            IList<Produto> produtos = this.produtoDAO.ProdutosDaCategoriaComPrecoMaiorDoQue(preco, nomeCategoria);
            return View(produtos);
        }

        public ActionResult BuscaDinamica(double? preco, string nome, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.Nome = nome;
            ViewBag.NomeCategoria = nomeCategoria;

            IList<Produto> produtos = produtoDAO.BuscaPorPrecoCategoriaENome(preco, nomeCategoria, nome);
            return View(produtos);
        }
        public ActionResult ListaPaginada(int? pagina)
        {
            int paginaAtual = pagina.GetValueOrDefault(1);
            ViewBag.Pagina = paginaAtual;
            IList<Produto> produtos = new List<Produto>();
            return View(produtos);
        }
    }
}
