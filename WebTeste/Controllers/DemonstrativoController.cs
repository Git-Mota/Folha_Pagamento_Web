using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using WebTeste.Data;
using WebTeste.Models;

namespace WebTeste.Controllers
{
    public class DemonstrativoController : Controller
    {
        private readonly BancoContext _bancoContext;
        public DemonstrativoController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
                var identity = User.Identity as ClaimsIdentity;
                var idFunClaim = identity.FindFirst("Id_Func");
                int convert = int.Parse(idFunClaim.Value);
                var demostrativoSQL = _bancoContext.Tab_Demostrativo.FromSqlRaw("SELECT Tab_Demostrativo.IdDemonstrativo AS IdDemons, Tab_Demostrativo.IdFuncionario AS IdFunc, Tab_Funcionario.NomeCompleto AS nome, Tab_Funcionario.CPF AS cpf," +
                              "Tab_Funcionario.tb_ValValeRefeicao AS valeRefeicao, Tab_Funcionario.tb_ValTransporte AS valeTransporte, Tab_Funcionario.tb_ValHora AS valorHora," +
                              "Tab_Funcionario.tb_HoraSemanal AS HoraSemanal, Tab_Funcionario.tb_Cargo AS cargo, Tab_Demostrativo.DataFinal AS dataInicio, Tab_Demostrativo.DataFinal AS dataFinal," +
                              "Tab_Demostrativo.SalarioBase AS salarioBase, Tab_Demostrativo.SalarioFinal as salarioFinal, Tab_Demostrativo.INSS as inss, " +
                              "Tab_Demostrativo.ImpostoRenda as impostoRenda " +
                              "FROM Tab_Funcionario LEFT JOIN Tab_Demostrativo ON Tab_Funcionario.Id = Tab_Demostrativo.IdFuncionario WHERE Tab_Funcionario.Id =" + convert).ToList();
                    return View(demostrativoSQL);
                
        }

        public IActionResult Consulta() {

            return View();

        }
    }
}
