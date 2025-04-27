using CafeCentral.Models;

namespace CafeCentral.Services
{
    public static class StaticDataService
    {
        public static List<Produto> Produtos { get; } = new List<Produto>
        {
            new Produto
            {
                Id = 1,
                Nome = "Frango Grelhado com Legumes",
                Descricao = "Peito de frango grelhado com mix de legumes frescos",
                Preco = 21.90M,
                Categoria = "Proteína",
                ImagemUrl = "/images/frango-grelhado.jpg",
                Disponivel = true
            },
            new Produto
            {
                Id = 2,
                Nome = "Bife Acebolado",
                Descricao = "Bife bovino acebolado com arroz integral e feijão",
                Preco = 23.90M,
                Categoria = "Proteína",
                ImagemUrl = "/images/bife-acebolado.jpg",
                Disponivel = true
            },
            new Produto
            {
                Id = 3,
                Nome = "Salmão Grelhado",
                Descricao = "Salmão grelhado com ervas, acompanha purê de batata doce",
                Preco = 32.90M,
                Categoria = "Proteína",
                ImagemUrl = "/images/salmao-grelhado.jpg",
                Disponivel = true
            },
            new Produto
            {
                Id = 4,
                Nome = "Marmita Vegana",
                Descricao = "Mix de legumes, grãos e tofu grelhado",
                Preco = 24.90M,
                Categoria = "Vegano",
                ImagemUrl = "/images/marmita-vegana.jpg",
                Disponivel = true
            },
            new Produto
            {
                Id = 5,
                Nome = "Low Carb",
                Descricao = "Proteínas e legumes, sem adição de carboidratos",
                Preco = 25.90M,
                Categoria = "Low Carb",
                ImagemUrl = "/images/low-carb.jpg",
                Disponivel = true
            },
            new Produto
            {
                Id = 6,
                Nome = "Pasta Integral",
                Descricao = "Macarrão integral com molho de tomate caseiro e almôndegas",
                Preco = 22.90M,
                Categoria = "Massa",
                ImagemUrl = "/images/pasta-integral.jpg",
                Disponivel = true
            }
        };

        public static List<string> GetCategorias()
        {
            return Produtos.Select(p => p.Categoria).Distinct().ToList();
        }

        public static Produto? GetProdutoById(int id)
        {
            return Produtos.FirstOrDefault(p => p.Id == id);
        }

        public static List<Produto> GetProdutosByCategoria(string? categoria)
        {
            var produtos = Produtos.Where(p => p.Disponivel);
            
            if (!string.IsNullOrEmpty(categoria))
            {
                produtos = produtos.Where(p => p.Categoria == categoria);
            }
            
            return produtos.ToList();
        }
    }
}