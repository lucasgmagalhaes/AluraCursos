using LojaWeb.Entidades;
using System.Collections.Generic;

namespace LojaWeb.Models
{
    public class Carrinho
    {
        public IList<Produto> Produtos { get; set; }

        public Carrinho()
        {
            Produtos = new List<Produto>();
        }
        public void Adiciona(Entidades.Produto produto)
        {
            Produtos.Add(produto);
        }

        public Venda CriaVenda(Usuario usuario)
        {
            return new Venda()
            {
                Produtos = Produtos,
                Cliente = usuario
            };
        }
    }
}
