﻿namespace LojaWeb.Entidades
{
    public abstract class Usuario
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }
    }
}