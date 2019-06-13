using LojaWeb.Entidades;
using NHibernate;
using System.Collections.Generic;

namespace LojaWeb.DAO
{
    public class UsuariosDAO
    {
        private readonly ISession session;

        public UsuariosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(usuario);
            transaction.Commit();
        }

        public void Remove(Usuario usuario)
        {

        }

        public void Atualiza(Usuario usuario)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Update(usuario);
            transaction.Commit();
        }

        public Usuario BuscaPorId(int id)
        {
            ITransaction transaction = session.BeginTransaction();
            Usuario usuario = session.Get<Usuario>(id);
            transaction.Commit();
            return usuario;
        }

        public IList<Usuario> Lista()
        {
            return new List<Usuario>();
        }
    }
}