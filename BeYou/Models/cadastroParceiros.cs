using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeYou.Models
{
    [Table("cadastroParceiros")]
    public class cadastroParceiros
    {
        [Key]
        public int ID { get; set; } 
        [Required]
        public string nome_parceiro { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string mensagem_parceiro { get; set; }
    }
}
