using LojaWeb.Entidades;
using NHibernate;
using NHibernate.Criterion;
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