using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class UsuariosDAO
    {
        public void Adiciona(Usuario usuario)
        {
            Database.usuarios.Add(usuario);
        }

        public IList<Usuario> Lista()
        {
            return Database.usuarios;
        }

        public Usuario BuscaPorId(int id)
        {
            return Database.usuarios.SingleOrDefault(usuario => usuario.Id == id);
        }

        public void Atualiza(Usuario usuario)
        {
            var user = Database.usuarios.SingleOrDefault(_usuario => _usuario.Id == usuario.Id);
            if (user != null)
            {
                user = usuario;
            }
        }

        public Usuario Busca(string login, string senha)
        {
            return Database.usuarios.SingleOrDefault(usuario => usuario.Nome == login && usuario.Senha == senha);
        }
    }
}