using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebTeste.Data;

namespace WebTeste.Controllers
{
    public class ConsultFeriasController : Controller
    {
        private readonly BancoContext _bancoContext;
        public ConsultFeriasController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Consulta()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var idFunClaim = identity.FindFirst("Id_Func");
                int convert = int.Parse(idFunClaim.Value);
                if (idFunClaim != null)
                {
   
                        var feriasSQL = _bancoContext.Tab_Funcionario_Ferias.FromSqlRaw("SELECT Tab_Funcionario.NomeCompleto AS Nome, Tab_Funcionario.CPF AS CPF, " +
                                  "Tab_Funcionario.tb_Departamento AS Departamento, Tab_Funcionario.LocalidadeAtual AS Localidade," +
                                  " Tab_Ferias.Tb_DataInicioFerias AS 'DataInicioFerias', Tab_Ferias.Tb_DataFinalFerias AS 'DataTerminoFerias'," +
                                  "Tab_Ferias.Tb_AnoAquisitivo AS 'AnoAquisitivo', Tab_Ferias.Tb_QuantidadeDiasParcela AS QuantDias" +
                                  " FROM Tab_Funcionario LEFT JOIN Tab_Ferias ON Tab_Funcionario.Id = Tab_Ferias.Tb_IdFuncionario WHERE Tab_Funcionario.Id =" + convert).ToList();
                        return View(feriasSQL);
                    
              
                }
            }
                return View(); 
        }
    }
}
