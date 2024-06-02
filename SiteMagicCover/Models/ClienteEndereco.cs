using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMagicCover.Models
{
    [Table("ClientesEndereco")]
    public class ClienteEndereco
    {
        [Key]
        public int ClienteEnderecoId { get; set; }

        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [StringLength(15)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        [StringLength(15)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        [StringLength(15)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [StringLength(15)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a Rua")]
        [StringLength(15)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Informe o Número da Casa")]
        [StringLength(15)]
        public string Numero { get; set; }

        [StringLength(30)]
        public string Informacao { get; set; }

        
        public virtual Cliente Cliente { get; set; }

    }
}
