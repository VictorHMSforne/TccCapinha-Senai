using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMagicCover.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem
    {
        [Key]
        public int CarinhoCompraItemId { get; set; }
        public Capinha Capinha { get; set; }
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
