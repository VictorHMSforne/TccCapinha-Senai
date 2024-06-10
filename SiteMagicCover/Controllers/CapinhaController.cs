using SiteMagicCover.Repositories.Interfaces;
using SiteMagicCover.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Models;

namespace SiteMagicCover.Controllers
{
    public class CapinhaController : Controller
    {
        private readonly ICapinhaRepository _capinhaRepository;

        public CapinhaController(ICapinhaRepository capinhaRepository)
        {
            _capinhaRepository = capinhaRepository;
        }
        public IActionResult Listar(string categoria)
        {
            IEnumerable<Capinha> capinhas;
            string categoriaAtual = string.Empty;

            //if (string.IsNullOrEmpty(categoria))
            //{
            //    capinhas = _capinhaRepository.Capinhas.OrderBy(c => c.CapinhaId);
            //    categoriaAtual = "Todas as Capinhas";
            //    ViewData["Titulo"] = categoriaAtual;
            //}
            //else
            //{

            //    capinhas = _capinhaRepository.Capinhas
            //        .Where(c => c.Categoria.CategoriaNome.Equals(categoria))
            //        .OrderBy(c => c.Marca);
            //    categoriaAtual = categoria;
            //    ViewData["Titulo"] = categoriaAtual;
            //}
            if (string.IsNullOrEmpty(categoria))
            {
                capinhas = _capinhaRepository.Capinhas.Where(c => !c.IsPersonalizada).OrderBy(c => c.CapinhaId);
                categoriaAtual = "Todas as Capinhas";
                ViewData["Titulo"] = categoriaAtual;
            }
            else
            {
                capinhas = _capinhaRepository.Capinhas
                    .Where(c => c.Categoria.CategoriaNome.Equals(categoria) && !c.IsPersonalizada)
                    .OrderBy(c => c.Marca);
                categoriaAtual = categoria;
                ViewData["Titulo"] = categoriaAtual;
            }
            var capinhasListViewModel = new CapinhaListViewModel
            {
                Capinhas = capinhas,
                CategoriaAtual = categoriaAtual
            };

            

            return View(capinhasListViewModel);
     

            // Revisar esses conceitos:ViewBag,ViewData,TempData os Repositories, também _ViewStart e _ViewImports

            
            //ViewData["Data"] = DateTime.Now;
            //TempData["Nome"] = "Rodolfo";


            //var totalCapinhas = capinhas.Count();

            //ViewBag.Total = "Total de Capinhas : ";
            //ViewBag.TotalCapinhas = totalCapinhas;

            //return View(capinhas);

            /* No codigo acima, era usado apenas os dados das capinhas, agora embaixo utiliza-se os dados da capinha
             e da categoria em uma única View, resumindo: Pode-se manipular os dois dados, Capinhas e categorias*/

            //var CapinhaListViewModel = new CapinhaListViewModel();
            //CapinhaListViewModel.Capinhas = _capinhaRepository.Capinhas;
            //CapinhaListViewModel.CategoriaAtual = "Categoria Atual";


        }

        public ViewResult Pesquisar(string searchString)
        {
            IEnumerable<Capinha> capinhas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                capinhas = _capinhaRepository.Capinhas.OrderBy(c => c.CapinhaId);
                categoriaAtual = "Todas as Capinhas";
                ViewData["Titulo"] = categoriaAtual;

            }
            else
            {
                capinhas = _capinhaRepository.Capinhas
                    .Where(c => c.NomeCelular.ToLower().Contains(searchString.ToLower()));
                if (capinhas.Any())
                {
                    categoriaAtual = "Capinhas";
                    ViewData["Titulo"] = categoriaAtual;
                }
                else
                {
                    categoriaAtual = "Nenhuma capinha foi encontrada";
                    ViewData["Titulo"] = categoriaAtual;
                }
                      
            }
            return View("~/Views/Capinha/Listar.cshtml", new CapinhaListViewModel
            {
                Capinhas = capinhas,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
