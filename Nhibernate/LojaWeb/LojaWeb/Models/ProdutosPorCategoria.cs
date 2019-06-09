using LojaWeb.Entidades;

namespace LojaWeb.Models
{
    public class ProdutosPorCategoria
    {
        public Categoria Categoria { get; set; }

        public long NumeroDeProdutos { get; set; }
    }
}