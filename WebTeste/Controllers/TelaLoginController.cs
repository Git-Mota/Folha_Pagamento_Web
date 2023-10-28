﻿using Microsoft.AspNetCore.Mvc;
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
                var funcionario = _bancoContext.Tab_Funcionario.FirstOrDefault(func => func.Id == usuario.db_Id_Funcionario);
                var nome = funcionario.NomeCompleto;
                var departamento = funcionario.tb_Departamento;
                if (funcionario != null)
                {
                    // Crie um ClaimsIdentity com as informações do funcionário
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, funcionario.NomeCompleto),
                        new Claim("Departamento", funcionario.tb_Departamento)
                    };
                    
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    // Crie um ClaimsPrincipal com o ClaimsIdentity
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    // Faça a autenticação do usuário com o ClaimsPrincipal
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    /*
                    var viewModel = new HomeModel()
                    {
                        Nome = funcionario.NomeCompleto
                    };
                    */
                    return RedirectToAction("Index", "Home"/*,viewModel*/);
                }
            }
            ViewBag.ErroMessage = "CPF ou senha invalidos";
            return View();
        }
    }
}