using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CafeCentral.Data;
using CafeCentral.Models;
using CafeCentral.Extensions;

namespace CafeCentral.Controllers
{
    public class CardapioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CardapioController> _logger;
        private const string CarrinhoSessionKey = "Carrinho";

        public CardapioController(ApplicationDbContext context, ILogger<CardapioController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Cardapio
        public async Task<IActionResult> Index(string categoria = null)
        {
            ViewBag.Categorias = await _context.Produtos
                .Select(p => p.Categoria)
                .Distinct()
                .ToListAsync();

            var produtos = _context.Produtos.Where(p => p.Disponivel);

            if (!string.IsNullOrEmpty(categoria))
            {
                produtos = produtos.Where(p => p.Categoria == categoria);
                ViewBag.CategoriaAtual = categoria;
            }

            return View(await produtos.ToListAsync());
        }

        // GET: Cardapio/Detalhes/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Cardapio/AdicionarAoCarrinho
        [HttpPost]
        public IActionResult AdicionarAoCarrinho(int produtoId, int quantidade = 1)
        {
            // Buscar produto no banco
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null)
            {
                return NotFound();
            }

            // Obter carrinho da sessão ou criar um novo
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();

            // Verificar se o produto já está no carrinho
            var item = carrinho.FirstOrDefault(c => c.ProdutoId == produtoId);
            if (item != null)
            {
                // Incrementar quantidade
                item.Quantidade += quantidade;
            }
            else
            {
                // Adicionar novo item
                carrinho.Add(new CarrinhoItem
                {
                    ProdutoId = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = quantidade,
                    ImagemUrl = produto.ImagemUrl ?? "/images/placeholder.jpg"
                });
            }

            // Salvar carrinho na sessão
            HttpContext.Session.Set(CarrinhoSessionKey, carrinho);

            // Redirecionar para o carrinho ou continuar comprando
            TempData["MensagemSucesso"] = $"{produto.Nome} adicionado ao carrinho!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Cardapio/Carrinho
        public IActionResult Carrinho()
        {
            // Obter carrinho da sessão
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();
            
            // Calcular total
            ViewBag.Total = carrinho.Sum(i => i.Subtotal);
            
            return View(carrinho);
        }

        // POST: Cardapio/RemoverDoCarrinho/5
        [HttpPost]
        public IActionResult RemoverDoCarrinho(int produtoId)
        {
            // Obter carrinho da sessão
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();
            
            // Remover item
            var item = carrinho.FirstOrDefault(c => c.ProdutoId == produtoId);
            if (item != null)
            {
                carrinho.Remove(item);
                HttpContext.Session.Set(CarrinhoSessionKey, carrinho);
            }
            
            return RedirectToAction(nameof(Carrinho));
        }

        // POST: Cardapio/AtualizarCarrinho
        [HttpPost]
        public IActionResult AtualizarCarrinho(int produtoId, int quantidade)
        {
            // Obter carrinho da sessão
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();
            
            // Atualizar quantidade
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

        // POST: Cardapio/LimparCarrinho
        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            HttpContext.Session.Remove(CarrinhoSessionKey);
            return RedirectToAction(nameof(Carrinho));
        }

        [HttpGet]
        public IActionResult FinalizarPedido()
        {
            // Verificar se há itens no carrinho
            var carrinho = HttpContext.Session.Get<List<CarrinhoItem>>(CarrinhoSessionKey) ?? new List<CarrinhoItem>();
            if (!carrinho.Any())
            {
                TempData["MensagemErro"] = "Seu carrinho está vazio!";
                return RedirectToAction(nameof(Carrinho));
            }
            
            // Calcular total
            ViewBag.Total = carrinho.Sum(i => i.Subtotal);
            ViewBag.Carrinho = carrinho;
            
            return RedirectToAction("FinalizarPedido", "Pedido");
        }
    }
}