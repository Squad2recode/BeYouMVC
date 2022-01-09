using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeYou.Models
{
    [Table("cadastroVoluntarios")]
    public class cadastroVoluntarios
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nome_voluntario { get; set; }
        [Required]
        public int idade { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string mensagem_voluntario { get; set; }
    }
}
