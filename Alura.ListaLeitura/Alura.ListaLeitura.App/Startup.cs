using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("livros/paraLer", LivrosParaLer);
            builder.MapRoute("livros/lendo", LivrosLendo);
            builder.MapRoute("livros/lidos", LivrosLidos);
            builder.MapRoute("livros/detalhe/{id:int}", ExibirDetalhe);
            builder.MapRoute("cadastro/novoLivro/{nome}/{autor}", NovoLivro);
            builder.MapRoute("cadastro/novoLivro", ExibirFormulario);
            builder.MapRoute("cadastroLivro/novo", ProcessaFormulario);
            app.UseRouter(builder.Build());
            //app.Run(Roteamento);
        }

        public Task ExibirFormulario(HttpContext context)
        {
            var html = @"
                    <html>
                    <form action='/cadastroLivro/novo'>
                        <input name='titulo' />
                        <input name='autor' />
                        <button>Gravar</button>
                    </form>
                    </html>";

            return context.Response.WriteAsync(html);
        }

        public Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = context.Request.Query["titulo"].First(),
                Autor = context.Request.Query["autor"].First()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("Livro inserido com sucesso");
        }

        public Task ExibirDetalhe(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(_livro => _livro.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public Task NovoLivro(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("Livro inserido com sucesso");
        }

        public Task Roteamento(HttpContext context)
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();
            var rotas = new Dictionary<string, RequestDelegate>()
            {
                { "/livros/paraLer",  LivrosParaLer},
                { "/livros/lendo",  LivrosLendo},
                { "/livros/lidos",  LivrosLidos}
            };

            if (rotas.ContainsKey(context.Request.Path))
            {
                return rotas[context.Request.Path].Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente");
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.ParaLer.ToString());
        }

        public Task LivrosLendo(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            var repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(repo.Lidos.ToString());
        }
    }
}