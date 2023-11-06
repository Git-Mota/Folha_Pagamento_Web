using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTeste.Models
{
    public class PontoModel
    {
       
        [Key]
        public int? db_IdPonto { get; set; }
        public int db_IdFuncionario { get; set; }  
        public DateTime db_Data { get; set; }
        public string? db_DiaSemana { get; set; }
        public TimeSpan? db_HoraSaida { get; set; }
        public TimeSpan? db_HoraEntrada { get; set; }
        public TimeSpan? db_HoraInicioAlmoco { get; set; }
        public TimeSpan? db_db_HoraRetornoAlmoco { get; set; }
        public TimeSpan? db_HoraInicioPausa { get; set; }
        public TimeSpan? db_HoraRetornoPausa { get; set; }
    }
}
