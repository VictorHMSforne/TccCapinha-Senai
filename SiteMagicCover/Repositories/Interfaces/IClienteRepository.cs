using SiteMagicCover.Models;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        void CriarPedido(ClienteEPedidoViewModel clienteEPedidoViewModel); //mudei aqui
        List<ClientePedido> GetPedidosDoCliente(int clienteId); 
    }
}
