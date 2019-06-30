using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class ProdutosDAO
    {

        public void Adiciona(Produto produto)
        {
            Database.produtos.Add(produto);
        }

        public IList<Produto> Lista()
        {
            return Database.produtos;
        }

        public Produto BuscaPorId(int id)
        {
            return Database.produtos.SingleOrDefault(produto => produto.Id == id);
        }

        public void Atualiza(Produto produto)
        {
            var prod = Database.produtos.SingleOrDefault(_produto => _produto.Id == produto.Id);
            if(prod != null)
            {
                prod = produto;
            }
        }
    }
}