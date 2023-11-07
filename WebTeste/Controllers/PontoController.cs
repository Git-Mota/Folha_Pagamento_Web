﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;
using WebTeste.Data;
using WebTeste.Models;

namespace WebTeste.Controllers
{
    public class PontoController : Controller
    {
        private readonly BancoContext _bancoContext;
        public PontoController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

 

        public IActionResult Index(int RecId)
        {
            
                if (TempData["Mensagem"] != null)
                {
                    ViewBag.Mensagem = TempData["Mensagem"];
                }
               
           
            var identity = User.Identity as ClaimsIdentity;
            var idFunClaim = identity.FindFirst("Id_Func");
            int convert = int.Parse(idFunClaim.Value);
            var pontoSQL= _bancoContext.Tab_Ponto.FromSqlRaw("SELECT Tab_Ponto.db_IdPonto, Tab_Ponto.db_IdFuncionario ,Tab_Funcionario.NomeCompleto," +
                 "Tab_Funcionario.tb_Departamento, Tab_Ponto.db_Data,"+
                 "Tab_Ponto.db_DiaSemana, Tab_Ponto.db_HoraSaida,"+
                 "Tab_Ponto.db_HoraEntrada, Tab_Ponto.db_HoraInicioAlmoco, "+
                 "Tab_Ponto.db_db_HoraRetornoAlmoco, Tab_Ponto.db_HoraInicioPausa,"+
                 "Tab_Ponto.db_HoraRetornoPausa" +
                 " FROM Tab_Funcionario LEFT JOIN Tab_Ponto ON Tab_Funcionario.Id = Tab_Ponto.db_IdFuncionario WHERE Tab_Funcionario.Id =" + convert).ToList();
            return View(pontoSQL);
        }
        public IActionResult CriarPonto()
        {
            var identity = User.Identity as ClaimsIdentity;
            var idFunClaim = identity.FindFirst("Id_Func");
            int convert = int.Parse(idFunClaim.Value);
            var pontoSQL = _bancoContext.Tab_Ponto.FromSqlRaw("SELECT Tab_Ponto.db_IdPonto AS 'IdPonto', Tab_Ponto.db_IdFuncionario AS 'IdFuncionario',Tab_Funcionario.NomeCompleto AS Nome," +
                 "Tab_Funcionario.tb_Departamento AS Departamento, Tab_Ponto.db_Data AS Data," +
                 "Tab_Ponto.db_DiaSemana AS 'DiaSemana', Tab_Ponto.db_HoraSaida AS 'HoraSaida'," +
                 "Tab_Ponto.db_HoraEntrada AS 'HoraEntrada', Tab_Ponto.db_HoraInicioAlmoco AS 'HoraInicioAlmoco'," +
                 "Tab_Ponto.db_db_HoraRetornoAlmoco AS 'HoraRetornoAlmoco', Tab_Ponto.db_HoraInicioPausa AS 'HoraInicioPausa'," +
                 "Tab_Ponto.db_HoraRetornoPausa AS 'HoraRetornoPausa'" +
                 "FROM Tab_Funcionario LEFT JOIN Tab_Ponto ON Tab_Funcionario.Id = Tab_Ponto.db_IdFuncionario WHERE Tab_Funcionario.Id =" + convert).ToList();
            return View(pontoSQL);

        }
        [HttpPost]
        public IActionResult SalvarAlteracoes(List<PontoModel> pontos)
        {
            if (ModelState.IsValid)
            {
                foreach (var ponto in pontos)
                {
                    _bancoContext.Tab_Ponto.Add(ponto);
                }

                _bancoContext.SaveChanges(); // Isso irá salvar os dados no banco de dados
            }

            return RedirectToAction("Index"); // Redirecionar para a página principal após a inserção
        }

        [HttpPost]
        public IActionResult SalvarPonto (PontoModel passaPonto, string tipoPonto)
        {
            var identity = User.Identity as ClaimsIdentity;
            var idFunClaim = identity.FindFirst("Id_Func");
            int convert = int.Parse(idFunClaim.Value);
            int id = convert;

            var existiPonto = _bancoContext.Tab_Ponto.FirstOrDefault(p =>
                p.db_IdFuncionario == id &&
                p.db_Data == passaPonto.db_Data &&
                (p.db_HoraEntrada != null
                ));

            switch (tipoPonto)
            {
                case "PontEntrada":
  
                    if (existiPonto != null)
                    {
                       //PASSAR MENGAEM QUE PONTO JÁ EXISTE.
                    }
                    else
                    {
                        var novoPonto = new PontoModel
                        {
                            db_IdFuncionario = id,
                            db_Data = passaPonto.db_Data,
                            db_DiaSemana = passaPonto.db_DiaSemana,
                            db_HoraEntrada = passaPonto.db_HoraEntrada,
                        };

                        _bancoContext.Tab_Ponto.Add(novoPonto);
                        _bancoContext.SaveChanges();
                    }
                    break;
                case "PontoIniAlmo":

                    var existiPontoIniAlmo = _bancoContext.Tab_Ponto.FirstOrDefault(p =>
                          p.db_IdFuncionario == id &&
                          p.db_Data == passaPonto.db_Data &&
                          (tipoPonto == "PontoIniAlmo" && p.db_HoraInicioAlmoco != null));

                    var atualizaPonto = _bancoContext.Tab_Ponto.FirstOrDefault(p =>
                          p.db_IdFuncionario == id &&
                          p.db_Data == passaPonto.db_Data &&
                          p.db_HoraInicioAlmoco == null);


                    if (existiPonto != null && existiPontoIniAlmo == null)
                    {
                        atualizaPonto.db_HoraInicioAlmoco = passaPonto.db_HoraInicioAlmoco;
                        _bancoContext.SaveChanges();
                    }
                    else
                    {
                        TempData["Mensagem"] = "Não existe nenhuma entrada para o inicio do expediente.";
                        ViewBag.Mensagem = TempData["Mensagem"];
                        return RedirectToAction("Index");
                        
                    }

                    break;
                default:
                    break;
            }




             
            return RedirectToAction("Index");

         

        }

    }
}

