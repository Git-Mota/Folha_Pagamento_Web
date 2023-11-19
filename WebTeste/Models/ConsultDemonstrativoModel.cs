using System.ComponentModel.DataAnnotations;
namespace WebTeste.Models
{
    public class ConsultDemonstrativoModel
    {

        public string nome { get; set; }
        [Key]
        public string cpf { get; set; }
        public  decimal valeRefeicao { get; set;}
        public decimal valeTransporte{get; set;}
        public decimal valorHora { get; set; }
        public decimal valorHoraSemanal { get; set; }
        public string cargo { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFinal { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal SalarioFinal { get;}
        public decimal inss { get; set; }
        public decimal impostoRenda{ get; set;}
        public decimal horasPendentes { get; set; }

    }
}
