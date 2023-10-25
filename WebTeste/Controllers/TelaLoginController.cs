using Microsoft.AspNetCore.Mvc;

namespace WebTeste.Controllers
{
    public class TelaLoginController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
    }
}
