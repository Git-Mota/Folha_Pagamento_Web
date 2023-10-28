using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebTeste.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebTeste.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;


namespace WebTeste.Controllers
{
    
    public class TelaLoginController : Controller
    {
        private readonly BancoContext _bancoContext;
        public TelaLoginController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UsuarioModel model)
        {
            var usuario = _bancoContext.Tab_Usuario.FirstOrDefault(usr => usr.db_Cpf == model.db_Cpf && usr.db_Senha == model.db_Senha);
            if (usuario != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.ErroMessage = "CPF ou senha invalidos";
                return View();
            }
        }
  

        
    }
}
