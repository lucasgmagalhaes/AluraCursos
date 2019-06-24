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
            session.Save(usuario);
        }

        public void Remove(Usuario usuario)
        {

        }

        public void Atualiza(Usuario usuario)
        {
            session.Update(usuario);
        }

        public Usuario BuscaPorId(int id)
        {
            Usuario usuario = session.Get<Usuario>(id);
            return usuario;
        }

        public IList<Usuario> Lista()
        {
            IQuery query = session.CreateQuery("from Usuario");
            query.SetCacheable(true);
            return query.List<Usuario>();
        }
    }
}