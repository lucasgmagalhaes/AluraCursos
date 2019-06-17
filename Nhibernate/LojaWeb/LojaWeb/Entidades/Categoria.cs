using System.Collections.Generic;

namespace LojaWeb.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}