using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CafeCentral.Models;
using CafeCentral.Data;

namespace CafeCentral.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // Podemos usar o ViewBag para passar dados simples para a view
        ViewBag.Title = "Marmitas Fitness de Qualidade";
        ViewBag.Subtitle = "Refeições saudáveis, saborosas e balanceadas para quem busca uma alimentação de qualidade no dia a dia";
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewBag.Title = "Sobre Nós";
        ViewBag.Description = "A nossa missão é prover uma alimentação nutritiva e equilibrada para pessoas com ritmo de vida acelerado, sem abrir mão da qualidade.";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}