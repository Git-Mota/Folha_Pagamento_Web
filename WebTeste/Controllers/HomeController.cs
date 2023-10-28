using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTeste.Models;

namespace WebTeste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(/*HomeModel viewModel*/)
        {
            return View(/*viewModel*/);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}