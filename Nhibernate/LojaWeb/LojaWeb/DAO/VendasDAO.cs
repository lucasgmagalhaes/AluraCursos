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
            session.Save(venda);
        }

        public IList<Venda> Lista()
        {
            IQuery query = session.CreateQuery("from venda");
            return query.List<Venda>();
        }
    }
}