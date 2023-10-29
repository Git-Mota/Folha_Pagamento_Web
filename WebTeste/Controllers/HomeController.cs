using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTeste.Models;

namespace WebTeste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(/*HomeModel viewModel*/)
        {
            var nomeCompleto = User.Identity.Name;
            if (nomeCompleto == null)
            {
                TempData["Mensagem"] = "Por favor, faça login para acessar esta página.";
                return RedirectToAction("Login", "TelaLogin");
            }

            return View();
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}