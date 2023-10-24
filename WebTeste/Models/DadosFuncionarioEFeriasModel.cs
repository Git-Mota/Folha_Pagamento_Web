using System.ComponentModel.DataAnnotations;

namespace WebTeste.Models
{
    public class DadosFuncionarioEFeriasModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Departamento { get; set; }
        public string Localidade { get; set; }
        public DateTime? DataInicioFerias { get; set; }
        public DateTime? DataTerminoFerias { get; set; }
    }
}
