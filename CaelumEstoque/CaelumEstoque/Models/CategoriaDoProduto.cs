﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class CategoriaDoProduto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public String Nome { get; set; }

        public String Descricao { get; set; }
    }
}