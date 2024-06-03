using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMagicCover.Models
{
    [Table("CapinhasPersonalizadas")]
    public class CapinhaPersonalizada
    {
        [Key]
        public int CapinhaPersoId { get; set; }

        [Required(ErrorMessage = "O nome da Marca deve ser informado")]
        [Display(Name = "Marca Do Celular")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O nome do Modelo deve ser informado")]
        [Display(Name = "Modelo Do Celular")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Modelo { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemMockup { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemFinal { get; set; }
        public int ClienteId { get; set; }


        public virtual Cliente Cliente { get; set; }
        public ICollection<ClientePedido> ClientePedidos { get; set; }
        public ICollection<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
