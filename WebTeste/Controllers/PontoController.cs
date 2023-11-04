﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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

        public IActionResult Index(int RecId )
        {
            var identity = User.Identity as ClaimsIdentity;
            var idFunClaim = identity.FindFirst("Id_Func");
            int convert = int.Parse(idFunClaim.Value);
            var pontoSQL= _bancoContext.Tab_Ponto.FromSqlRaw("SELECT Tab_Ponto.db_IdPonto AS 'IdPonto', Tab_Ponto.db_IdFuncionario AS 'IdFuncionario',Tab_Funcionario.NomeCompleto AS Nome," +
                 "Tab_Funcionario.tb_Departamento AS Departamento, Tab_Ponto.db_Data AS Data,"+
                 "Tab_Ponto.db_DiaSemana AS 'DiaSemana', Tab_Ponto.db_HoraSaida AS 'HoraSaida',"+
                 "Tab_Ponto.db_HoraEntrada AS 'HoraEntrada', Tab_Ponto.db_HoraInicioAlmoco AS 'HoraInicioAlmoco',"+
                 "Tab_Ponto.db_db_HoraRetornoAlmoco AS 'HoraRetornoAlmoco', Tab_Ponto.db_HoraInicioPausa AS 'HoraInicioPausa',"+
                 "Tab_Ponto.db_HoraRetornoPausa AS 'HoraRetornoPausa'" +
                 "FROM Tab_Funcionario LEFT JOIN Tab_Ponto ON Tab_Funcionario.Id = Tab_Ponto.db_IdFuncionario WHERE Tab_Funcionario.Id =" + convert).ToList();
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
        public IActionResult SalvarPonto (PontoModel passaPonto)
        {
           
                var novoPonto = new PontoModel
                {
                    Nome = passaPonto.Nome,
                    Departamento = passaPonto.Departamento,
                    Data = passaPonto.Data,
                    DiaSemana = passaPonto.DiaSemana
                    
                };

                _bancoContext.Tab_Ponto.Add(novoPonto);
                _bancoContext.SaveChanges();
                return RedirectToAction("Index");

          

        }

    }
}

