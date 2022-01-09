using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeYou.Models
{
    [Table("cadastroCursos")]
    public class cadastroCursos
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nome_instituicao { get; set; }
        [Required]
        public string curso { get; set; }
        [Required]
        public string cidade_UF { get; set; }
        [Required]
        public string duracao { get; set; }
        [Required]
        public string turno { get; set; }
    }
}
