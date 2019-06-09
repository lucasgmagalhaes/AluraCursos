using LojaWeb.Entidades;
using NHibernate;
using System.Collections.Generic;

namespace LojaWeb.DAO
{
    public class VendasDAO
    {
        private ISession session;

        public VendasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Venda venda)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(venda);
            transaction.Commit();
        }

        public IList<Venda> Lista()
        {
            return new List<Venda>();
        }
    }
}