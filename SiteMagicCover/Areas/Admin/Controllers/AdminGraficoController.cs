using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Areas.Admin.Servicos;

namespace SiteMagicCover.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficosVendaService _graficosVendas;

        public AdminGraficoController(GraficosVendaService graficosVendas)
        {
            _graficosVendas = graficosVendas ?? throw
                new ArgumentNullException(nameof(graficosVendas));
        }

        public JsonResult VendasCapinhas(int dias)
        {
            var capinhasVendasTotais = _graficosVendas.GetVendasCapinhas(dias);
            return Json(capinhasVendasTotais);
        }

        [HttpGet]
        public IActionResult Index() //Vendas Anuais
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
