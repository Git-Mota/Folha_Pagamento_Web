using Microsoft.AspNetCore.Mvc;

namespace WebTeste.Controllers
{
    public class FeriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
