using LojaWeb.Entidades;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

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
            ITransaction transaction = session.BeginTransaction();
            session.Save(produto);
            transaction.Commit();
        }

        public void Remove(Produto produto)
        {

        }

        public void Atualiza(Produto produto)
        {

        }

        public Produto BuscaPorId(int id)
        {
            return null;
        }

        public List<Produto> Lista()
        {
            IQuery query = session.CreateQuery("from produto");
            return query.List<Produto>().ToList();
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            IQuery query = session.CreateQuery("from produto where preco > :minimo");
            query.SetParameter("minimo", preco.GetValueOrDefault(0));
            return query.List<Produto>().ToList();
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            IQuery query = session.CreateQuery("from produto p where p.Categoria.Nome = :nomeCategoria");
            query.SetParameter("nomeCategoria", nomeCategoria);
            return query.List<Produto>().ToList();
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            IQuery query = session.CreateQuery("from produto p where p.Categoria.Nome = :nomeCategoria and p.preco > :preco");
            query.SetParameter("nomeCategoria", nomeCategoria);
            query.SetParameter("preco", preco.GetValueOrDefault(0.0));
            return query.List<Produto>().ToList();
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