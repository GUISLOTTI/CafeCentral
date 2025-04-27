using Microsoft.AspNetCore.Mvc;
using CafeCentral.Models;
using CafeCentral.Extensions;
using CafeCentral.Services;

namespace CafeCentral.Controllers
{
    public class CardapioController : Controller
    {
        private readonly ILogger<CardapioController> _logger;
        private const string CarrinhoSessionKey = "Carrinho";

        public CardapioController(ILogger<CardapioController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index(string categoria = null)
        {
            ViewBag.Categorias = StaticDataService.GetCategorias();
            
            var produtos = StaticDataService.GetProdutosByCategoria(categoria);
            
            if (!string.IsNullOrEmpty(categoria))
            {
                ViewBag.CategoriaAtual = categoria;
            }

            return View(produtos);
        }

        
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = StaticDataService.GetProdutoById(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        
        [HttpPost]
        public IActionResult AdicionarAoCarrinho(int produtoId, int quantidade = 1)
        {
            
            var produto = StaticDataService.GetProdutoById(produtoId);
            if (produto == null)
            {
                return NotFound();
            }

            
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();

            
            var item = carrinho.FirstOrDefault(c => c.ProdutoId == produtoId);
            if (item != null)
            {
                
                item.Quantidade += quantidade;
            }
            else
            {
                
                carrinho.Add(new CarrinhoItem
                {
                    ProdutoId = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = quantidade,
                    ImagemUrl = produto.ImagemUrl ?? "/images/placeholder.jpg"
                });
            

        
            HttpContext.Session.Set(CarrinhoSessionKey, carrinho);

            
            TempData["MensagemSucesso"] = $"{produto.Nome} adicionado ao carrinho!";
            return RedirectToAction(nameof(Index));
        }
      
            HttpContext.Session.Set(CarrinhoSessionKey, carrinho);

            
            TempData["MensagemSucesso"] = $"{produto.Nome} adicionado ao carrinho!";
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Carrinho()
        {
            
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();

            
            ViewBag.Total = carrinho.Sum(i => i.Subtotal);

            return View(carrinho);
        }

        
        [HttpPost]
        public IActionResult RemoverDoCarrinho(int produtoId)
        {
            
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();

            
            var item = carrinho.FirstOrDefault(c => c.ProdutoId == produtoId);
            if (item != null)
            {
                carrinho.Remove(item);
                HttpContext.Session.Set(CarrinhoSessionKey, carrinho);
            }

            return RedirectToAction(nameof(Carrinho));
        }

        
        [HttpPost]
        public IActionResult AtualizarCarrinho(int produtoId, int quantidade)
        {
            
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();

            
            var item = carrinho.FirstOrDefault(c => c.ProdutoId == produtoId);
            if (item != null)
            {
                if (quantidade <= 0)
                {
                    carrinho.Remove(item);
                }
                else
                {
                    item.Quantidade = quantidade;
                }

                HttpContext.Session.Set(CarrinhoSessionKey, carrinho);
            }

            return RedirectToAction(nameof(Carrinho));
        }

        
        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            HttpContext.Session.Remove(CarrinhoSessionKey);
            return RedirectToAction(nameof(Carrinho));
        }

        [HttpGet]
        public IActionResult FinalizarPedido()
        {
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();

            if (!carrinho.Any())
            {
                TempData["MensagemErro"] = "Seu carrinho está vazio!";
                return RedirectToAction(nameof(Carrinho));
            }

            decimal total = carrinho.Sum(i => i.Subtotal);

            
            var mensagem = "Olá, gostaria de finalizar meu pedido:\n";
            foreach (var item in carrinho)
            {
                mensagem += $"- {item.Quantidade}x {item.Nome} (R${item.Preco:F2} cada)\n";
            }

            mensagem += $"Total: R${total:F2}";

            
            string numeroWhatsapp = "5547996738906";
            string urlWhatsapp = $"https://wa.me/{numeroWhatsapp}";

            return Redirect(urlWhatsapp);
        }
    }
}