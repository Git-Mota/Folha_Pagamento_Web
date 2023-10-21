using Microsoft.AspNetCore.Mvc;

namespace WebTeste.Controllers
{
    public class PontoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CriarPonto()
        {
            return View();
        }
    }
}
