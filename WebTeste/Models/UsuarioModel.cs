using System.ComponentModel.DataAnnotations;
//using static WebTeste.Models.FuncionarioModel;
using static WebTeste.Models.FuncionarioModel;



namespace WebTeste.Models
{
    public class UsuarioModel
    {
        [Key] public int db_Id { get; set; }
        public int db_Id_Funcionario { get; set; }
        public string db_Cpf { get; set; }
        public string db_Senha { get; set; }
        public FuncionarioModel Funcionario { get; set; }
         
    

    }
}
