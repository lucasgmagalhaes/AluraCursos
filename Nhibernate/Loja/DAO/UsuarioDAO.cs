using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAO
{
    public class UsuarioDAO
    {
        private ISession session;

        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }

        public void Adicionar(Usuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();
        }

        public Usuario BuscarPorId(int id)
        {
            return session.Get<Usuario>(id);
        }
    }
}
