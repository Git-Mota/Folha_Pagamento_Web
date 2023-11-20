using System.ComponentModel.DataAnnotations;
namespace WebTeste.Models
{
    public class ConsultDemonstrativoModel
    {
        [Key]
        public int IdDemons { get; set; }
        public int IdFunc {  get; set; }
        public string? nome { get; set; }
        public string? cpf { get; set; }
        public  decimal? valeRefeicao { get; set;}
        public decimal? valeTransporte {get; set;}
        public decimal? valorHora { get; set; }
        public decimal? HoraSemanal { get; set; }
        public string? cargo { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFinal { get; set; }
        public decimal? salarioBase { get; set; }
        public decimal? salarioFinal { get; set; }
        public decimal? inss { get; set; }
        public decimal? impostoRenda { get; set;}
       // public decimal horasPendentes { get; set; }


    }
}
