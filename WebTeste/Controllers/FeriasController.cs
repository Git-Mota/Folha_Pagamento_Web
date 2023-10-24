using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTeste.Data;
using WebTeste.Models;

namespace WebTeste.Controllers
{
    public class FeriasController : Controller
    {
        private readonly BancoContext _bancoContext;
        public FeriasController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }



        [HttpGet("testarconexao")]
        public IActionResult TestarConexao()
        {
            try
            {
                _bancoContext.Database.OpenConnection();
                _bancoContext.Database.CloseConnection();
                return Ok("Conexão bem sucedida");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro de conexão: { ex.Message}");
                throw;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdicionarFerias()
        {
            return View();
        }

        /*  public IActionResult ConsultarFerias()
          {
              IEnumerable<FeriasModel> ferias = _bancoContext.Tab_Ferias;
              return View(ferias);
        }  */
       
        public IActionResult ConsultarFerias(int RecId)
        {
            var feriasSQL = _bancoContext.Tab_Ferias.FromSqlRaw("SELECT * FROM Tab_Ferias WHERE Tab_Ferias.Tb_IdFuncionario = {0}",RecId).ToList();
            return View(feriasSQL);
        }

    }
}
