using SiteMagicCover.Models;
using System.ComponentModel.DataAnnotations;

namespace SiteMagicCover.ViewModels
{
    public class ClienteEPedidoViewModel
    {
        public ClienteEPedidoViewModel()
        {
            ClientePedidos = new List<ClientePedido>(); 
        }

        public int/*?*/ ClienteId { get; set; } // Opcional para novos clientes
        public int ClientePedidoId { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Sobrenome")]
        [StringLength(100)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos e não pode conter letras")]
        [StringLength(20)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o Telefone")]
        [StringLength(25)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve conter 10 ou 11 dígitos.")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "O endereço de e-mail não é válido.")]
        public string Email { get; set; }

        // Propriedades do Pedido
        [Required(ErrorMessage = "Informe a Capinha")]
        public int CapinhaId { get; set; }

        [Display(Name = "Preço Individual do Pedido")]
        public double Preco { get; set; }

        [Display(Name = "Quantidade de Itens Individuais do Pedido")]
        public int Quantidade { get; set; }


        [ScaffoldColumn(false)] // Para não Aparecer na View
        [Display(Name = "Total do Pedido")]
        public double PedidoTotal { get; set; }

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

        public virtual List<ClientePedido> ClientePedidos { get; set; }
        
    }
}
