using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SiteMagicCover.Context;
using SiteMagicCover.Models;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Controllers
{
    public class CapinhaPersoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CapinhaPersoController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; // se der erro usa o this._webHostEnvironment
        }



        // GET: Capinhas/Customizar
        public IActionResult Customizar()
        {
            return View();
        }

        // POST: Capinhas/Customizar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Customizar(CapinhaViewModel viewModel, string finalImage)
        {
            //if (ModelState.IsValid)
            //{
            //    // Handle image upload
            //    string uniqueFileName = null;
            //    if (viewModel.ImagemFile != null)
            //    {
            //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "imagensUser");
            //        // Create the directory if it doesn't exist
            //        if (!Directory.Exists(uploadsFolder))
            //        {
            //            Directory.CreateDirectory(uploadsFolder);
            //        }

            //        // Get the logged-in user's name
            //        string userName = User.Identity.Name;
            //        // Sanitize the username to avoid any filesystem issues
            //        userName = string.Concat(userName.Split(Path.GetInvalidFileNameChars()));

            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + userName + "_" + viewModel.ImagemFile.FileName;
            //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await viewModel.ImagemFile.CopyToAsync(fileStream);
            //        }
            //    }

            //    var capinha = new Capinha
            //    {
            //        Marca = viewModel.Marca,
            //        Modelo = viewModel.Modelo,
            //        NomeCelular = viewModel.NomeCelular,
            //        Preco = viewModel.Preco,
            //        ImagemUrl = Path.Combine("images", "imagensUser", uniqueFileName), // relative path for storing in the database
            //        ImagemThumbUrl = Path.Combine("images", "imagensUser", uniqueFileName), // Use the same image for thumbnail if not provided separately
            //        Disponibilidade = viewModel.Disponibilidade,
            //        IsPersonalizada = viewModel.IsPersonalizada,
            //        ImagemFile = viewModel.ImagemFile,
            //        CategoriaId = viewModel.CategoriaId
            //    };

            //    _context.Add(capinha);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index)); // Assuming you have an Index action to display capinhas
            //}

            if (ModelState.IsValid)
            {
                // Handle image upload
                string uniqueFileName = null;
                if (!string.IsNullOrEmpty(finalImage))
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "imagensUser");
                    // Create the directory if it doesn't exist
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Get the logged-in user's name
                    string userName = User.Identity.Name;
                    // Sanitize the username to avoid any filesystem issues
                    userName = string.Concat(userName.Split(Path.GetInvalidFileNameChars()));

                    // Convert the base64 image data to bytes
                    byte[] imageBytes = Convert.FromBase64String(finalImage.Replace("data:image/png;base64,", ""));

                    // Generate a unique filename
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + userName + ".png";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Write the image bytes to the file
                    await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);
                }

                var capinha = new Capinha
                {
                    Marca = viewModel.Marca,
                    Modelo = viewModel.Modelo,
                    NomeCelular = viewModel.NomeCelular,
                    Preco = viewModel.Preco,
                    ImagemUrl = Path.Combine("images", "imagensUser", uniqueFileName), // relative path for storing in the database
                    ImagemThumbUrl = Path.Combine("images", "imagensUser", uniqueFileName), // Use the same image for thumbnail if not provided separately
                    Disponibilidade = viewModel.Disponibilidade,
                    IsPersonalizada = viewModel.IsPersonalizada,
                    CategoriaId = viewModel.CategoriaId
                };

                _context.Add(capinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Assuming you have an Index action to display capinhas
            }
            return View(viewModel);
        }














        // Simular banco de dados para marcas e modelos
        //private static readonly Dictionary<string, List<string>> MarcasModelos = new Dictionary<string, List<string>>
        //{
        //    { "Iphone", new List<string> { "15 Pro Max", "14" } },
        //    { "Samsung", new List<string> { "S24", "Note 10" } }
        //};

        //public IActionResult Index()
        //{
        //    ViewBag.Marcas = MarcasModelos.Keys;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Personalizar(string marca, string modelo)
        //{
        //    // Redireciona para a página de personalização com a marca e modelo selecionados
        //    return RedirectToAction("Customizar", new { marca, modelo });
        //}

        //public IActionResult Customizar(string marca, string modelo)
        //{
        //    ViewBag.Marca = marca;
        //    ViewBag.Modelo = modelo;
        //    return View();
        //}

        //[HttpGet]
        //public JsonResult GetModelos(string marca)
        //{
        //    if (MarcasModelos.ContainsKey(marca))
        //    {
        //        return Json(MarcasModelos[marca]);
        //    }
        //    return Json(new List<string>());
        //}
    }
}
