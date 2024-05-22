using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CapinhaController : Controller
    {
        private readonly ICapinhaRepository _capinhaRepository;

        public CapinhaController(ICapinhaRepository capinhaRepository)
        {
            _capinhaRepository = capinhaRepository;
        }
        public IActionResult Listar()
        {
            var capinhas = _capinhaRepository.Capinhas;

            // Revisar esses conceitos:ViewBag,ViewData,TempData

            ViewData["Titulo"] = "Todas as Capinhas";
            //ViewData["Data"] = DateTime.Now;
            //TempData["Nome"] = "Rodolfo";

            
            //var totalCapinhas = capinhas.Count();

            //ViewBag.Total = "Total de Capinhas : ";
            //ViewBag.TotalCapinhas = totalCapinhas;

            return View(capinhas);
        }
    }
}
