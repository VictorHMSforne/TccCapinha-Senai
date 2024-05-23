﻿using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
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
            //var capinhas = _capinhaRepository.Capinhas;

            // Revisar esses conceitos:ViewBag,ViewData,TempData e também os Repositories

            ViewData["Titulo"] = "Todas as Capinhas";
            //ViewData["Data"] = DateTime.Now;
            //TempData["Nome"] = "Rodolfo";


            //var totalCapinhas = capinhas.Count();

            //ViewBag.Total = "Total de Capinhas : ";
            //ViewBag.TotalCapinhas = totalCapinhas;

            //return View(capinhas);

            /* No codigo acima, era usado apenas os dados das capinhas, agora embaixo utiliza-se os dados da capinha
             e da categoria em uma única View, resumindo: Pode-se manipular os dois dados, Capinhas e categorias*/

            var CapinhaListViewModel = new CapinhaListViewModel();
            CapinhaListViewModel.Capinhas = _capinhaRepository.Capinhas;
            CapinhaListViewModel.CategoriaAtual = "Categoria Atual";

            return View(CapinhaListViewModel);
        }
    }
}
