using SiteMagicCover.Repositories.Interfaces;
using SiteMagicCover.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace SiteMagicCover.Controllers
{
    public class CapinhaController : Controller
    {
        private readonly ICapinhaRepository _capinhaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CapinhaController(ICapinhaRepository capinhaRepository, IWebHostEnvironment webHostEnvironment)
        {
            _capinhaRepository = capinhaRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Listar(string categoria)
        {


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


            //CODIGO FUNFANDO AQUI:
            //IEnumerable<Capinha> capinhas;
            //string categoriaAtual = string.Empty;


            //if (string.IsNullOrEmpty(categoria))
            //{
            //    capinhas = _capinhaRepository.Capinhas.Where(c => !c.IsPersonalizada).OrderBy(c => c.CapinhaId);
            //    categoriaAtual = "Todas as Capinhas";
            //    ViewData["Titulo"] = categoriaAtual;
            //}
            //else
            //{
            //    capinhas = _capinhaRepository.Capinhas
            //        .Where(c => c.Categoria.CategoriaNome.Equals(categoria) && !c.IsPersonalizada)
            //        .OrderBy(c => c.Marca);
            //    categoriaAtual = categoria;
            //    ViewData["Titulo"] = categoriaAtual;
            //}
            //var capinhasListViewModel = new CapinhaListViewModel
            //{
            //    Capinhas = capinhas,
            //    CategoriaAtual = categoriaAtual
            //};

            //CODIGO MELHORADO FUNFANDO PARTE 2 AQUI:

            //IEnumerable<Capinha> capinhas;
            //string categoriaAtual = string.Empty;
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obter o ID do usuário logado

            //if (string.IsNullOrEmpty(categoria))
            //{
            //    capinhas = _capinhaRepository.Capinhas.OrderBy(c => c.CapinhaId);
            //    categoriaAtual = "Todas as Capinhas";
            //}
            //else if (categoria.Equals("Suas Capinhas"))
            //{
            //    capinhas = _capinhaRepository.Capinhas
            //        .Where(c => c.IsPersonalizada && c.UserId == userId)
            //        .OrderBy(c => c.CapinhaId);
            //    categoriaAtual = "Suas Capinhas";
            //}
            //else
            //{
            //    capinhas = _capinhaRepository.Capinhas
            //        .Where(c => c.Categoria.CategoriaNome.Equals(categoria) && !c.IsPersonalizada)
            //        .OrderBy(c => c.Marca);
            //    categoriaAtual = categoria;
            //}

            //ViewData["Titulo"] = categoriaAtual;

            //var capinhasListViewModel = new CapinhaListViewModel
            //{
            //    Capinhas = capinhas,
            //    CategoriaAtual = categoriaAtual
            //};

            //return View(capinhasListViewModel);

            IEnumerable<Capinha> capinhas;
            string categoriaAtual = string.Empty;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obter o ID do usuário logado

            if (string.IsNullOrEmpty(categoria))
            {
                capinhas = _capinhaRepository.Capinhas
                    .Where(c => !c.IsPersonalizada) // Exibir apenas capinhas que não são personalizadas
                    .OrderBy(c => c.CapinhaId);
                categoriaAtual = "Todas as Capinhas";
            }
            else if (categoria.Equals("Suas Capinhas"))
            {
                capinhas = _capinhaRepository.Capinhas
                    .Where(c => c.IsPersonalizada && c.UserId == userId) // Exibir apenas capinhas personalizadas do usuário logado
                    .OrderBy(c => c.CapinhaId);
                categoriaAtual = "Suas Capinhas";
                if (!capinhas.Any())
                {
                    string mensagem = "Você não personalizou nenhuma capinha ainda.";
                    ViewData["Mensagem"] = mensagem;
                }
            }
            else
            {
                capinhas = _capinhaRepository.Capinhas
                    .Where(c => c.Categoria.CategoriaNome.Equals(categoria) && !c.IsPersonalizada) // Exibir capinhas de uma categoria específica que não são personalizadas
                    .OrderBy(c => c.Marca);
                categoriaAtual = categoria;
            }

            ViewData["Titulo"] = categoriaAtual;

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

        //[HttpPost]
        //[Authorize]
        //public IActionResult Delete(int capinhaId)
        //{
        //    var capinhaSelecionada = _capinhaRepository.Capinhas
        //        .FirstOrDefault(p => p.CapinhaId == capinhaId);
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var capinha = _capinhaRepository.Capinhas.FirstOrDefault(c => c.CapinhaId == capinhaId && c.UserId == userId);

        //    if (capinha == null)
        //    {
        //        return NotFound(); // Ou outra resposta apropriada, como Forbidden
        //    }

        //    _capinhaRepository.DeleteCapinha(capinha);
        //    _capinhaRepository.Save();

        //    return RedirectToAction("Listar", new { categoria = "Suas Capinhas" });
        //}
        [Authorize]

        public IActionResult Delete(int capinhaId)
        {
            var capinha = _capinhaRepository.GetCapinhaById(capinhaId); // Suponha que o método GetCapinhaById retorna uma Capinha pelo seu ID

            if (capinha == null)
            {
                return NotFound();
            }

            return View(capinha);
        }

        // Action para confirmar a exclusão
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int capinhaId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var capinha = _capinhaRepository.Capinhas.FirstOrDefault(c => c.CapinhaId == capinhaId && c.UserId == userId);

            if (capinha != null)
            {
                if (!string.IsNullOrEmpty(capinha.ImagemUrl))
                {
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, capinha.ImagemUrl.Replace('\\', '/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                _capinhaRepository.DeleteCapinha(capinha);
                _capinhaRepository.Save();
            }

            return RedirectToAction("Listar", new { categoria = "Suas Capinhas" });
        }

    }
}
