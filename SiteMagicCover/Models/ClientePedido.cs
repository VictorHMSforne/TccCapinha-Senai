using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMagicCover.Models
{
    [Table("ClientePedido")]
    public class ClientePedido
    {
        [Key]
        public int ClientePedidoId { get; set; }

        public int ClienteId { get; set; }
        public int CapinhaId { get; set; }
        


        [Display(Name = "Preço Individual do Pedido")]
        public double Preco { get; set; }

        [ScaffoldColumn(false)] // Para não Aparecer na View
        [Display(Name = "Total do Pedido")]
        public double PedidoTotal { get; set; }

        [Display(Name = "Quantidade de Itens Individuais do Pedido")]
        public int Quantidade { get; set; }

        [ScaffoldColumn(false)] 
        [Display(Name = "Quantidade de Itens no Pedido")]
        public int TotalItensPedido { get; set; }

        [Display(Name = "Data de Envio do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data de Entrega do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregueEm { get; set; }



        public virtual Capinha Capinha { get; set; }
        public virtual Cliente Cliente { get; set; }
        


    }
}
