using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CafeCentral.Models;

namespace CafeCentral.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
}