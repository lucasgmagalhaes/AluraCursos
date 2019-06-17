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
            session.Save(categoria);
        }

        public void Remove(Categoria categoria)
        {

        }

        public void Atualiza(Categoria categoria)
        {
            session.Update(categoria);
        }

        public Categoria BuscaPorId(int id)
        {
            Categoria categoria = session.Get<Categoria>(id);
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