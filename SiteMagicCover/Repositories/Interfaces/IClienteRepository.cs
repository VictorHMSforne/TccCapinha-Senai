using SiteMagicCover.Models;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        List<ClientePedido> CriarPedido(ClienteEPedidoViewModel clienteEPedidoViewModel); //mudei aqui
        List<ClientePedido> GetPedidosDoCliente(int clienteId); 
    }
}
