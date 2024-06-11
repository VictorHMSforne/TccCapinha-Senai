using SiteMagicCover.Context;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories.Interfaces;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public ClienteRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        //public void CriarPedido(ClienteEPedidoViewModel clienteEPedidoViewModel) //mudei aqui
        //{
        //    if (_appDbContext.Clientes.Any(c => c.ClienteId == cliente.ClienteId) == false)
        //    {
        //        _appDbContext.Clientes.Add(cliente);
        //        _appDbContext.SaveChanges();
        //    }

        //    var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;
        //    foreach(var carrinhoItem in carrinhoCompraItens)
        //    {
        //        var clientePedido = new ClientePedido
        //        {
        //            PedidoEnviado = DateTime.Now,
        //            Quantidade = carrinhoItem.Quantidade,
        //            CapinhaId = carrinhoItem.Capinha.CapinhaId,
        //            ClienteId = cliente.ClienteId,
        //            Preco = carrinhoItem.Capinha.Preco
        //        };
        //        _appDbContext.ClientePedidos.Add(clientePedido);
        //    }
        //    _appDbContext.SaveChanges();
        //}
        public List<ClientePedido> CriarPedido(ClienteEPedidoViewModel clienteEPedidoViewModel)
        {
            // Verifica se o cliente já existe pelo CPF
            var clienteExistente = _appDbContext.Clientes.SingleOrDefault(c => c.CPF == clienteEPedidoViewModel.CPF);

            Cliente cliente;
            if (clienteExistente == null)
            {
                cliente = new Cliente
                {
                    Nome = clienteEPedidoViewModel.Nome,
                    Sobrenome = clienteEPedidoViewModel.Sobrenome,
                    CPF = clienteEPedidoViewModel.CPF,
                    Telefone = clienteEPedidoViewModel.Telefone,
                    Email = clienteEPedidoViewModel.Email
                };
                _appDbContext.Clientes.Add(cliente);
                _appDbContext.SaveChanges();
            }
            else
            {
                cliente = clienteExistente;
            }

            // Obtém os itens do carrinho de compra
            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            var pedidosCriados = new List<ClientePedido>();

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var clientePedido = new ClientePedido
                {
                    PedidoEnviado = DateTime.Now,
                    Quantidade = carrinhoItem.Quantidade,
                    CapinhaId = carrinhoItem.Capinha.CapinhaId,
                    ClienteId = cliente.ClienteId, // Associar o ClienteId correto
                    Preco = carrinhoItem.Capinha.Preco,
                    PedidoTotal = carrinhoItem.Capinha.Preco * carrinhoItem.Quantidade,
                    TotalItensPedido = clienteEPedidoViewModel.TotalItensPedido
                };

                _appDbContext.ClientePedidos.Add(clientePedido);
                pedidosCriados.Add(clientePedido);
            }

            _appDbContext.SaveChanges();

            return pedidosCriados;
        }

        public List<ClientePedido> GetPedidosDoCliente(int clienteId)
        {
            // Consulta os pedidos do cliente com o ID especificado
            return _appDbContext.ClientePedidos
                                  .Where(cp => cp.ClienteId == clienteId)
                                  .ToList();
        }


    }
}
