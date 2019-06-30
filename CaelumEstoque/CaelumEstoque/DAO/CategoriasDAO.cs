using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class CategoriasDAO
    {
        public void Adiciona(CategoriaDoProduto categoria)
        {
            Database.categorias.Add(categoria);
        }

        public IList<CategoriaDoProduto> Lista()
        {
            return Database.categorias;
        }

        public CategoriaDoProduto BuscaPorId(int id)
        {
            return Database.categorias.SingleOrDefault(categoria => categoria.Id == id);
        }

        public void Atualiza(CategoriaDoProduto categoria)
        {
           var cat = Database.categorias.SingleOrDefault(_categoria => _categoria.Id == categoria.Id);

            if(categoria != null)
            {
                cat = categoria;
            }
        }
    }
}