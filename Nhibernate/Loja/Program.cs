using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using NHibernate.Cfg;
using System;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateHelper.AbrirSessao();
            UsuarioDAO usuarioDao = new UsuarioDAO(session);

            Usuario usuario = new Usuario();
            usuario.Nome = "Lucas1";

            usuarioDao.Adicionar(usuario);
            session.Close();
            Console.Read();
        }
    }
}
