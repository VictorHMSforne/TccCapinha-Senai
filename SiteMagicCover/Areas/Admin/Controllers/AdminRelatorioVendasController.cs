using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Areas.Admin.Servicos;

namespace SiteMagicCover.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendasService RelatorioVendasService;

        public AdminRelatorioVendasController(RelatorioVendasService relatorioVendasService)
        {
            RelatorioVendasService = relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await RelatorioVendasService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}
