using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebTeste.Data;

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
            return View();
        }
    }
}
