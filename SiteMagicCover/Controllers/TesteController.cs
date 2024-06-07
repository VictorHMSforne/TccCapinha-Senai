using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult SelecaoMarcaModelo()
        {
            var viewModel = new TesteViewModel
            {
                // Preencher as listas de marcas e modelos a partir do banco de dados
                Marcas = GetMarcas(),
                Modelos = GetModelos()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CustomizarCapinha(TesteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Redirecionar para a página de customização com os parâmetros selecionados
                return RedirectToAction("CustomizarCapinha", new { marca = viewModel.Marca, modelo = viewModel.Modelo });
            }
            // Se houver erros de validação, retornar para a página de seleção de marca e modelo
            viewModel.Marcas = GetMarcas();
            viewModel.Modelos = GetModelos();
            return View("SelecaoMarcaModelo", viewModel);
        }
        [HttpPost]
        public IActionResult SalvarCapinha(string imageData)
        {
            // Lógica para salvar a imagem customizada
            // Por exemplo, você pode salvá-la no servidor
            // Aqui vamos apenas retornar uma mensagem de sucesso
            return Content("Capinha salva com sucesso!");
        }
        private List<SelectListItem> GetMarcas()
        {
            // Implemente a lógica para recuperar as marcas do banco de dados
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Apple", Text = "Apple" },
                new SelectListItem { Value = "Samsung", Text = "Samsung" },
                // Adicione mais marcas conforme necessário
            };
        }

        private List<SelectListItem> GetModelos()
        {
            // Implemente a lógica para recuperar os modelos do banco de dados
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "iPhone 15 Pro Max", Text = "iPhone 15 Pro Max" },
                new SelectListItem { Value = "Galaxy S22 Ultra", Text = "Galaxy S22 Ultra" },
                // Adicione mais modelos conforme necessário
            };
        }
        


        public IActionResult Testando()
        {
            return View();
        }
    }
}
