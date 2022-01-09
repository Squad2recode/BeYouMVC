using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeYou.Models
{
    [Table("cadastroVagasEmprego")]
    public class cadastroVagasEmprego
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nome_empresa { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        public string cidade_UF { get; set; }
        [Required]
        public string salario { get; set; }
        public string beneficios { get; set; }
    }
}
