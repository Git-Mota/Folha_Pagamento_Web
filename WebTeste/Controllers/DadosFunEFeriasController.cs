using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTeste.Data;

namespace WebTeste.Controllers
{
    public class DadosFunEFeriasController : Controller
    {
        private readonly BancoContext _bancoContext;
        public DadosFunEFeriasController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Teste()
        {
            var feriasSQL = _bancoContext.Tab_Funcionario_Ferias.FromSqlRaw("SELECT Tab_Funcionario.NomeCompleto AS Nome, Tab_Funcionario.CPF AS CPF, " +
                "Tab_Funcionario.tb_Departamento AS Departamento, Tab_Funcionario.LocalidadeAtual AS Localidade," +
                " Tab_Ferias.Tb_DataInicioFerias AS 'DataInicioFerias', Tab_Ferias.Tb_DataFinalFerias AS 'DataTerminoFerias'" +
                " FROM Tab_Funcionario LEFT JOIN Tab_Ferias ON Tab_Funcionario.Id = Tab_Ferias.Tb_IdFuncionario WHERE Tab_Funcionario.CPF = 44963754860").ToList();

            

            //var feriasSQL = _bancoContext.Tab_Ferias.FromSqlRaw("SELECT * FROM Tab_Ferias WHERE Tab_Ferias.Tb_IdFuncionario = {0}", RecId).ToList();
            return View(feriasSQL);
        }
    }
}
