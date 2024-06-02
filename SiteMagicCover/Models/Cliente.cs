using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMagicCover.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Sobrenome")]
        [StringLength(100)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [StringLength(20)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o Telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "O endereço de e-mail não é válido.")]
        public string Email { get; set; }

        public List<ClienteEndereco> ClienteEnderecos { get; set; }
        public List<ClientePedido> ClientePedidos { get; set; }


    }
}
