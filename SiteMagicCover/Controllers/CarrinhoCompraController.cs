using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories.Interfaces;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ICapinhaRepository _capinhaRepository; //Como é preciso acessar as capinhas e o carrinho de compras, instanciamos
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ICapinhaRepository capinhaRepository, 
            CarrinhoCompra carrinhoCompra)
        {
            _capinhaRepository = capinhaRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int capinhaId)
        {
            var capinhaSelecionada = _capinhaRepository.Capinhas
                .FirstOrDefault(p => p.CapinhaId == capinhaId);

            if (capinhaSelecionada != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(capinhaSelecionada);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int capinhaId)
        {
            var capinhaSelecionada = _capinhaRepository.Capinhas
               .FirstOrDefault(p => p.CapinhaId == capinhaId);

            if (capinhaSelecionada != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(capinhaSelecionada);
            }

            return RedirectToAction("Index");
        }
    }
}
