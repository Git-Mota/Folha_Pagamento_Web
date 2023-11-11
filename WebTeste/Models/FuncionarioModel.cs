using System.ComponentModel.DataAnnotations;
using WebTeste.Models;

namespace WebTeste.Models
{
    public class FuncionarioModel
    {
       [Key] public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string tb_Departamento { get; set; }
    }
}
