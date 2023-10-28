using System.ComponentModel.DataAnnotations;

namespace WebTeste.Models
{
    public class UsuarioModel
    {
        [Key] public int db_Id { get; set; }
        public string db_Cpf { get; set; }
        public string db_Senha { get; set; }

    }
}
