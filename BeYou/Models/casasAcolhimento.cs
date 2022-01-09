using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeYou.Models
{
    [Table("casasAcolhimento")]
    public class casasAcolhimento
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nome_casa { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public string cidade { get; set; }
    }
}
