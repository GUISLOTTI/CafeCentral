using Microsoft.AspNetCore.Mvc;

namespace CafeCentral.Controllers;

public class PedidoController : Controller
{
    public IActionResult FinalizarPedido()
    {
        string numeroWhatsapp = "5547999269788";
        string mensagem = "Olá, gostaria de finalizar meu pedido!";
        string urlWhatsapp = $"https://wa.me/{numeroWhatsapp}?text={Uri.EscapeDataString(mensagem)}";

        return Redirect(urlWhatsapp);
    }
}
