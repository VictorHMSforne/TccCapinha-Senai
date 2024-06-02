using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories.Interfaces;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Controllers
{
    public class ClientePedidoController : Controller
    {
       private readonly IClienteRepository _clienteRepository;
       private readonly CarrinhoCompra _carrinhoCompra;

        public ClientePedidoController(IClienteRepository clienteRepository, CarrinhoCompra carrinhoCompra)
        {
            _clienteRepository = clienteRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        public IActionResult Checkout() 
        {
          return View();
        }

        [HttpPost]
        public IActionResult Checkout(ClienteEPedidoViewModel clienteEPedidoViewModel)
        {
            int totalItensPedido = 0;
            double precoTotal = 0;

            //Aqui obtem os itens do carrinho de compra do Cliente
            List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            //Aqui é feito a verificação de itens do pedido
            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("","Seu carrinho está vazio");
            }

            //Calcula o total de Itens e do total do pedido
            foreach (var item in itens)
            {
                totalItensPedido += item.Quantidade;
                precoTotal += (item.Capinha.Preco * item.Quantidade);
            }

            //Atriuir os valores obtidos ao pedido
            clienteEPedidoViewModel.TotalItensPedido = totalItensPedido;
            clienteEPedidoViewModel.PedidoTotal = precoTotal;

            //Aqui é feito a validação dos dados do pedido
            if (ModelState.IsValid) // Se não possuir nenhum erro, ele retorna true
            {
                //Criação do pedido e os detalhes
                _clienteRepository.CriarPedido(clienteEPedidoViewModel);              //VERIFICAR DEPOIS AQUI
                clienteEPedidoViewModel.ClientePedidos = _clienteRepository.GetPedidosDoCliente(clienteEPedidoViewModel.ClienteId);

                //Definir Mensagens ao Cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu Pedido!";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                //limpar o Carrinho
                _carrinhoCompra.LimparCarrinho();

                //exibe a view com dados do cliente e do pedido
                return View("~/Views/ClientePedido/CheckoutCompleto.cshtml", clienteEPedidoViewModel);
            }
            return View(clienteEPedidoViewModel);
        }

    }
}
