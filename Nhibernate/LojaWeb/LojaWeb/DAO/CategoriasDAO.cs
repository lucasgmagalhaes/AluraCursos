using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using System.Collections.Generic;

namespace LojaWeb.DAO
{
    public class CategoriasDAO
    {
        private readonly ISession session;

        public CategoriasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Categoria categoria)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(categoria);
            transaction.Commit();
        }

        public void Remove(Categoria categoria)
        {

        }

        public void Atualiza(Categoria categoria)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Update(categoria);
            transaction.Commit();
        }

        public Categoria BuscaPorId(int id)
        {
            ITransaction transaction = session.BeginTransaction();
            Categoria categoria = session.Get<Categoria>(id);
            transaction.Commit();
            return categoria;
        }

        public IList<Categoria> Lista()
        {
            return new List<Categoria>();
        }

        public IList<Categoria> BuscaPorNome(string nome)
        {
            return new List<Categoria>();
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            return new List<ProdutosPorCategoria>();
        }
    }

}