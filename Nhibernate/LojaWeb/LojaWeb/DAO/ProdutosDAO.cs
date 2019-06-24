using LojaWeb.Entidades;
using NHibernate;
using NHibernate.Criterion;
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
            ICriteria criterio = session.CreateCriteria<Produto>();
            if (preco.HasValue)
            {
                criterio.Add(Restrictions.Gt("Preco", preco));
            }

            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria categoriaCriteria = criterio.CreateCriteria("Categoria");
                categoriaCriteria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }

            if (!string.IsNullOrEmpty(nome))
            {
                criterio.Add(Restrictions.Eq("Nome", nome));
            }

            return criterio.List<Produto>();
        }

        public IList<Produto> BuscaPorNomePrecoMinimoECategoria(string nome, double precoMinimo, string nomeCategoria)
        {
            ICriteria criterio = session.CreateCriteria<Produto>();
            if (!string.IsNullOrEmpty(nome))
            {
                criterio.Add(Restrictions.Eq("Nome", nome));
            }

            if (precoMinimo > 0)
            {
                criterio.Add(Restrictions.Ge("PrecoMinimo", precoMinimo));
            }

            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria criterioCategoria = criterio.CreateCriteria("Categoria");
                criterioCategoria.Add(Restrictions.Eq("Nome", nome));
            }

            return criterio.List<Produto>();
        }
    }
}