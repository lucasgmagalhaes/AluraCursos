﻿using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using NHibernate.Transform;
using System.Collections.Generic;
using System.Linq;

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

        }

        public Categoria BuscaPorId(int id)
        {
            return null;
        }

        public IList<Categoria> Lista()
        {
            return new List<Categoria>();
        }

        public List<Categoria> BuscaPorNome(string nome)
        {
            IQuery query = session.CreateQuery("from Categoria where nome = :nome");
            query.SetParameter("nome", nome);
            return query.List<Categoria>().ToList();
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            IQuery query = session.CreateQuery("select p.Categorias, count(p) as NumeroDeProdutos from produtos p group by p.categoria");
            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
            return query.List<ProdutosPorCategoria>().ToList();
        }
    }

}