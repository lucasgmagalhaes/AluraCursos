using LojaWeb.Entidades;
using NHibernate;
using System.Collections.Generic;

namespace LojaWeb.DAO
{
    public class ProdutosDAO
    {
        private readonly ISession session;

        public ProdutosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {
            session.Save(produto);
        }

        public void Remove(Produto produto)
        {

        }

        public void Atualiza(Produto produto)
        {
            session.Merge(produto);
        }

        public Produto BuscaPorId(int id)
        {
            Produto produto = session.Get<Produto>(id);
            return produto;
        }

        public IList<Produto> Lista()
        {
            return new List<Produto>();
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            return new List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            return new List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            return new List<Produto>();
        }

        public IList<Produto> ListaPaginada(int paginaAtual)
        {
            return new List<Produto>();
        }

        public IList<Produto> BuscaPorPrecoCategoriaENome(double? preco, string nomeCategoria, string nome)
        {
            return new List<Produto>();
        }
    }
}