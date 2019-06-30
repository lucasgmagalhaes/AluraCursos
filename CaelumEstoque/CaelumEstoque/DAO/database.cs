using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public static class Database
    {
        public static List<Produto> produtos = new List<Produto>()
        {
            new Produto() { Id = 1, Nome = "produto 1", Descricao = "des produto 1", Categoria = categorias[0], CategoriaId = categorias[0].Id, Preco = 1, Quantidade = 1},
            new Produto() { Id = 2, Nome = "produto 2", Descricao = "des produto 2", Categoria = categorias[1], CategoriaId = categorias[1].Id, Preco = 2, Quantidade = 2},
            new Produto() { Id = 3, Nome = "produto 3", Descricao = "des produto 3", Categoria = categorias[2], CategoriaId = categorias[2].Id, Preco = 3, Quantidade = 3},
            new Produto() { Id = 4, Nome = "produto 4", Descricao = "des produto 4", Categoria = categorias[3], CategoriaId = categorias[3].Id, Preco = 4, Quantidade = 4},
            new Produto() { Id = 5, Nome = "produto 5", Descricao = "des produto 5", Categoria = categorias[4], CategoriaId = categorias[4].Id, Preco = 5, Quantidade = 5},
            new Produto() { Id = 6, Nome = "produto 6", Descricao = "des produto 6", Categoria = categorias[5], CategoriaId = categorias[5].Id, Preco = 6, Quantidade = 6},
            new Produto() { Id = 7, Nome = "produto 7", Descricao = "des produto 7", Categoria = categorias[6], CategoriaId = categorias[6].Id, Preco = 7, Quantidade = 7}
        };

        public static List<CategoriaDoProduto> categorias = new List<CategoriaDoProduto>()
        {
            new CategoriaDoProduto() { Id = 1, Descricao = "desc cat 1", Nome = "cat 1"},
            new CategoriaDoProduto() { Id = 2, Descricao = "desc cat 2", Nome = "cat 2"},
            new CategoriaDoProduto() { Id = 3, Descricao = "desc cat 3", Nome = "cat 3"},
            new CategoriaDoProduto() { Id = 4, Descricao = "desc cat 4", Nome = "cat 4"},
            new CategoriaDoProduto() { Id = 5, Descricao = "desc cat 5", Nome = "cat 5"},
            new CategoriaDoProduto() { Id = 6, Descricao = "desc cat 6", Nome = "cat 6"},
            new CategoriaDoProduto() { Id = 7, Descricao = "desc cat 7", Nome = "cat 7"}
        };

        public static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario() { Id = 1, Nome = "usuario 1", Senha = "123"},
            new Usuario() { Id = 2, Nome = "usuario 2", Senha = "123"},
            new Usuario() { Id = 3, Nome = "usuario 3", Senha = "123"},
            new Usuario() { Id = 4, Nome = "usuario 4", Senha = "123"},
            new Usuario() { Id = 5, Nome = "usuario 5", Senha = "123"},
            new Usuario() { Id = 6, Nome = "usuario 6", Senha = "123"}
        };
    }
}