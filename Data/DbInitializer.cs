using CafeCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeCentral.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Produtos.Any())
                {
                    return;   // DB já foi populado
                }

                
                var produtos = new Produto[]
                {
                    new Produto
                    {
                        Nome = "Frango Grelhado com Legumes",
                        Descricao = "Peito de frango grelhado com mix de legumes frescos",
                        Preco = 21.90M,
                        Categoria = "Proteína",
                        ImagemUrl = "/images/frango-grelhado.jpg",
                        Disponivel = true
                    },
                    new Produto
                    {
                        Nome = "Bife Acebolado",
                        Descricao = "Bife bovino acebolado com arroz integral e feijão",
                        Preco = 23.90M,
                        Categoria = "Proteína",
                        ImagemUrl = "/images/bife-acebolado.jpg",
                        Disponivel = true
                    },
                    new Produto
                    {
                        Nome = "Salmão Grelhado",
                        Descricao = "Salmão grelhado com ervas, acompanha purê de batata doce",
                        Preco = 32.90M,
                        Categoria = "Proteína",
                        ImagemUrl = "/images/salmao-grelhado.jpg",
                        Disponivel = true
                    },
                    new Produto
                    {
                        Nome = "Marmita Vegana",
                        Descricao = "Mix de legumes, grãos e tofu grelhado",
                        Preco = 24.90M,
                        Categoria = "Vegano",
                        ImagemUrl = "/images/marmita-vegana.jpg",
                        Disponivel = true
                    },
                    new Produto
                    {
                        Nome = "Low Carb",
                        Descricao = "Proteínas e legumes, sem adição de carboidratos",
                        Preco = 25.90M,
                        Categoria = "Low Carb",
                        ImagemUrl = "/images/low-carb.jpg",
                        Disponivel = true
                    },
                    new Produto
                    {
                        Nome = "Pasta Integral",
                        Descricao = "Macarrão integral com molho de tomate caseiro e almôndegas",
                        Preco = 22.90M,
                        Categoria = "Massa",
                        ImagemUrl = "/images/pasta-integral.jpg",
                        Disponivel = true
                    }
                };

                foreach (var produto in produtos)
                {
                    context.Produtos.Add(produto);
                }

                context.SaveChanges();
            }
        }
    }
}