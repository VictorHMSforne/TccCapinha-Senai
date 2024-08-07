﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
       private readonly UserManager<IdentityUser> _userManager;

        public ClientePedidoController(IClienteRepository clienteRepository, CarrinhoCompra carrinhoCompra, UserManager<IdentityUser> userManager)
        {
            _clienteRepository = clienteRepository;
            _carrinhoCompra = carrinhoCompra;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Checkout() // é AQUI pra terminar a parte final de confirmação de dados
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null) 
            {
                var clienteEPedidoViewModel = new ClienteEPedidoViewModel
                {
                    Email = currentUser.Email,
                };    
                return View(clienteEPedidoViewModel);
            }
            
            else
            {
                // Se o usuário não estiver autenticado, redirecione para a página de login
                return RedirectToAction("Login", "Account");
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(ClienteEPedidoViewModel clienteEPedidoViewModel)
        {
            int totalItensPedido = 0;
            double precoTotal = 0;

            // Aqui obtem os itens do carrinho de compra do Cliente
            List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            // Aqui é feito a verificação de itens do pedido
            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio");
            }

            // Calcula o total de Itens e do total do pedido
            foreach (var item in itens)
            {
                totalItensPedido += item.Quantidade;
                precoTotal += (item.Capinha.Preco * item.Quantidade);
            }

            // Atribuir os valores obtidos ao pedido
            clienteEPedidoViewModel.TotalItensPedido = totalItensPedido;
            clienteEPedidoViewModel.PedidoTotal = precoTotal;

            // Aqui é feito a validação dos dados do pedido
            if (ModelState.IsValid) // Se não possuir nenhum erro, ele retorna true
            {
                // Criação do pedido e os detalhes
                var pedidosCriados = _clienteRepository.CriarPedido(clienteEPedidoViewModel);

                // Definir Mensagens ao Cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu Pedido!";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                // Limpar o Carrinho
                _carrinhoCompra.LimparCarrinho();

                // Exibe a view com dados do cliente e do pedido
                var clienteEPedidoViewModelCompleto = new ClienteEPedidoViewModel
                {
                    ClienteId = clienteEPedidoViewModel.ClienteId,
                    ClientePedidoId = pedidosCriados.First().ClientePedidoId,
                    ClientePedidos = pedidosCriados,
                    Nome = clienteEPedidoViewModel.Nome,
                    Sobrenome = clienteEPedidoViewModel.Sobrenome,
                    CPF = clienteEPedidoViewModel.CPF,
                    Telefone = clienteEPedidoViewModel.Telefone,
                    Email = clienteEPedidoViewModel.Email,
                    PedidoEnviado = pedidosCriados.First().PedidoEnviado
                };

                return View("~/Views/ClientePedido/CheckoutCompleto.cshtml", clienteEPedidoViewModelCompleto);
            }
            return View(clienteEPedidoViewModel);
        }

    }
}
