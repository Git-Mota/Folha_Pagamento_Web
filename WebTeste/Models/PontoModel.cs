using System.ComponentModel.DataAnnotations;

namespace WebTeste.Models
{
    public class PontoModel
    {
        [Key]
        public int? IdPonto { get; set; }
        public int? IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }    
        public DateTime Data { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraInicioAlmoco { get; set; }
        public TimeSpan HoraRetornoAlmoco { get; set; }
        public TimeSpan HoraInicioPausa { get; set; }
        public TimeSpan HoraRetornoPausa { get; set; }
    }
}
