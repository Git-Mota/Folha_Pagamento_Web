using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebTeste.Models

{
    public class FeriasModel
    {
        [Key]
        public int Tb_IdFerias { get; set; }
        public int Tb_IdFuncionario { get; set; }
        public DateTime Tb_DataInicioFerias { get; set; }
        public DateTime Tb_DataFinalFerias { get; set; }
        public int Tb_ParcelaFerias { get; set; }
        public int Tb_QuantidadeDiasParcela { get; set; }
        public int Tb_AnoAquisitivo { get; set; }
        public int Tb_QuantidadeFeriasPendentes { get; set; }
    }
}
