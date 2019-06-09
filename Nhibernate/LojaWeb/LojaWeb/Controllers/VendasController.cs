using LojaWeb.Entidades;
using LojaWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class VendasController : Controller
    {
        public ActionResult Index()
        {
            IList<Venda> vendas = new List<Venda>();
            return View(vendas);
        }
        public ActionResult ListaProdutos()
        {
            IList<Produto> produtos = new List<Produto>();
            ViewBag.ProdutosNoCarrinho = Carrinho.Produtos.Count;
            return View(produtos);
        }
        public ActionResult AdicionaProduto(int produtoId)
        {
            Produto produto = new Produto();
            Carrinho.Adiciona(produto);
            return RedirectToAction("ListaProdutos");
        }
        public ActionResult FechaPedido()
        {
            IList<Produto> produtos = Carrinho.Produtos;
            IList<Usuario> usuarios = new List<Usuario>();
            ViewBag.Usuarios = usuarios;
            return View(produtos);
        }
        public ActionResult CompletaPedido(int usuarioId)
        {
            Usuario usuario = new Usuario();
            Venda venda = Carrinho.CriaVenda(usuario);
            // grava venda
            Carrinho = new Carrinho();
            return RedirectToAction("Index");
        }
        public ActionResult LimpaCarrinho()
        {
            Carrinho = new Carrinho();
            return RedirectToAction("ListaProdutos");
        }

        // O Valor da propriedade Carrinho é armazenado na sessão
        private Carrinho Carrinho
        {
            get
            {
                Carrinho atual = Session["Carrinho"] as Carrinho;
                if (atual == null)
                {
                    atual = new Carrinho();
                    Session["Carrinho"] = atual;
                }
                return atual;
            }
            set => Session["Carrinho"] = value;
        }
    }
}
