using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteMagicCover.Context;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories;
using SiteMagicCover.Repositories.Interfaces;
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Controllers
{
    [Authorize]
    public class CapinhaPersonalizadaController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICapinhaPersonalizadaRepository _capinhaPersonalizadaRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IClienteRepository _clienteRepository; //
        private readonly IWebHostEnvironment _hostingEnvironment; 


        public CapinhaPersonalizadaController(ICapinhaPersonalizadaRepository capinhaPersonalizadaRepository, 
               UserManager<IdentityUser> userManager,
               IClienteRepository clienteRepository,
               AppDbContext appDbContext,
               IWebHostEnvironment webHostEnvironment)
        {
            _capinhaPersonalizadaRepository = capinhaPersonalizadaRepository;
            _userManager = userManager;
            _clienteRepository = clienteRepository;
            _appDbContext = appDbContext;
            _hostingEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Criar()
        {
            var model = new CapinhaPersonalizadaViewModel(); //
            return View(model);
            //var viewModel = new CapinhaPersonalizadaViewModel
            //{
            //    Marcas = _capinhaPersonalizadaRepository.GetMarcas(), // Suponha que você tenha um método para obter as marcas
            //    Modelos = _capinhaPersonalizadaRepository.GetModelos() // Suponha que você tenha um método para obter os modelos
            //};
            //return View(viewModel);
        }
        //[HttpPost]
        //public IActionResult SelecionarModelo(CapinhaPersonalizadaViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Aqui você pode redirecionar o usuário para a View de Personalização
        //        return RedirectToAction("Personalizar", new { marcaId = viewModel.MarcaId, modeloId = viewModel.ModeloId });
        //    }
        //    // Se houver erros de validação, retorne para a View Criar
        //    return View("Criar", viewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UploadImagem(PersonalizarCapinhaViewModel viewModel, IFormFile imagem)
        //{
        //    if (ModelState.IsValid && imagem != null && imagem.Length > 0)
        //    {
        //        // Manipular a imagem aqui (redimensionamento, aplicação sobre o mockup, etc.)
        //        var imagePath = await SalvarImagemAsync(viewModel.MarcaId, viewModel.ModeloId, imagem);

        //        // Salvar a informação da capinha no banco de dados
        //        var capinhaPersonalizada = new CapinhaPersonalizada
        //        {
        //            MarcaId = viewModel.MarcaId,
        //            ModeloId = viewModel.ModeloId,
        //            ImagemUrl = imagePath
        //        };

        //        _capinhaRepository.CriarCapinha(capinhaPersonalizada);

        //        return RedirectToAction("Index", "CarrinhoCompra");
        //    }

        //    // Se houver erros de validação ou se a imagem não for fornecida, retorne para a View Personalizar
        //    return View("Personalizar", viewModel);
        //}

        //private async Task<string> SalvarImagemAsync(int marcaId, int modeloId, IFormFile imagem)
        //{
        //    // Lógica para manipular a imagem (redimensionamento, aplicação sobre o mockup, etc.)
        //    // Salvar a imagem final na pasta do seu aplicativo e retornar o caminho da imagem

        //    // Exemplo de salvamento da imagem
        //    var uploadsPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        //    if (!Directory.Exists(uploadsPath))
        //    {
        //        Directory.CreateDirectory(uploadsPath);
        //    }
        //    var fileName = $"capinha_{marcaId}_{modeloId}_{Guid.NewGuid()}.png";
        //    var filePath = Path.Combine(uploadsPath, fileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await imagem.CopyToAsync(stream);
        //    }
        //    return $"/uploads/{fileName}";
        //}

        //[HttpPost]
        //public IActionResult SalvarMockup(string imagem, int marcaId, int modeloId)
        //{
        //    // Converta a imagem base64 de volta para bytes e salve-a no servidor
        //    // Lógica para salvar a imagem no servidor
        //    // Exemplo:
        //    // var bytes = Convert.FromBase64String(imagem.Split(',')[1]);
        //    // var fileName = $"capinha_{marcaId}_{modeloId}_{Guid.NewGuid()}.png";
        //    // var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);
        //    // System.IO.File.WriteAllBytes(filePath, bytes);

        //    // Retorne Ok() ou uma resposta apropriada
        //    return Ok();
        //}

























        [HttpPost]
        public async Task<IActionResult> Criar(CapinhaPersonalizadaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Salvar a imagem de personalização
                if (model.ImagemUrl != null && model.ImagemUrl.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imagesCapUser");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImagemUrl.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImagemUrl.CopyToAsync(fileStream);
                    }
                    model.ImagemMockup = uniqueFileName; // Salvando o nome do arquivo no modelo
                }
                ClienteEPedidoViewModel clienteEPedidoViewModel = new ClienteEPedidoViewModel();
                var clienteExistente = _appDbContext.Clientes.SingleOrDefault(c => c.CPF == clienteEPedidoViewModel.CPF);

                Cliente cliente;
                if (clienteExistente == null)
                {
                    cliente = new Cliente
                    {
                        ClienteId = clienteEPedidoViewModel.ClienteId,
                        Nome = clienteEPedidoViewModel.Nome,
                        Sobrenome = clienteEPedidoViewModel.Sobrenome,
                        CPF = clienteEPedidoViewModel.CPF,
                        Telefone = clienteEPedidoViewModel.Telefone,
                        Email = clienteEPedidoViewModel.Email
                    };
                    _appDbContext.Clientes.Add(cliente);
                    _appDbContext.SaveChanges();
                }
                else
                {
                    cliente = clienteExistente;
                    return RedirectToAction("Login", "Account");
                }
                // Criação da capinha personalizada no banco de dados
                
                var capinhaPersonalizada = new CapinhaPersonalizada
                {
                    Marca = model.Marca,
                    Modelo = model.Modelo,
                    ImagemMockup = model.ImagemMockup, // Salvando o nome do arquivo no modelo
                    ClienteId = cliente.ClienteId, // Verifique se é o ID correto do cliente
                    ImagemFinal = null, // Aqui deve ser criada uma lógica para gerar a imagem final
                    
                };

                await _capinhaPersonalizadaRepository.AddCapinhaPersonalizadaAsync(capinhaPersonalizada);
                await _capinhaPersonalizadaRepository.SaveChangesAsync();

                return RedirectToAction("Index", "Carrinho");
            }

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Criar(CapinhaPersonalizadaViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imagensCapinhas");
        //        var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagem.FileName;
        //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await model.Imagem.CopyToAsync(fileStream);
        //        }

        //        var currentUser = await _userManager.GetUserAsync(User);

        //        var capinhaPersonalizada = new CapinhaPersonalizada
        //        {
        //            Marca = model.Marca,
        //            Modelo = model.Modelo,
        //            ImagemPath = uniqueFileName,
        //            UsuarioId = currentUser.Id,
        //            DataCriacao = DateTime.Now
        //        };

        //        await _capinhaPersonalizadaRepository.AddCapinhaPersonalizadaAsync(capinhaPersonalizada);
        //        await _capinhaPersonalizadaRepository.SaveChangesAsync();

        //        // Adicionar ao carrinho logicamente aqui
        //        var carrinhoItem = new CarrinhoCompraItem
        //        {
        //            CapinhaPersonalizadaId = capinhaPersonalizada.Id,
        //            UsuarioId = currentUser.Id,
        //            Quantidade = 1
        //        };

        //        _context.CarrinhoCompraItems.Add(carrinhoItem);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Index", "Carrinho");
        //    }

        //    return View(model);
        //}

        //public async Task<IActionResult> Criar(CapinhaPersonalizadaViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imagensCapinhas");
        //        var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagem.FileName;
        //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await model.Imagem.CopyToAsync(fileStream);
        //        }

        //        var currentUser = await _userManager.GetUserAsync(User);

        //        var capinhaPersonalizada = new CapinhaPersonalizada
        //        {
        //            Marca = model.Marca,
        //            Modelo = model.Modelo,
        //            ImagemPath = uniqueFileName,
        //            UsuarioId = currentUser.Id,
        //            DataCriacao = DateTime.Now
        //        };

        //        await _capinhaPersonalizadaRepository.AddCapinhaPersonalizadaAsync(capinhaPersonalizada);
        //        await _capinhaPersonalizadaRepository.SaveChangesAsync();

        //        // Adicionar ao carrinho logicamente aqui
        //        var carrinhoItem = new CarrinhoCompraItem
        //        {
        //            CapinhaPersonalizadaId = capinhaPersonalizada.Id,
        //            UsuarioId = currentUser.Id,
        //            Quantidade = 1
        //        };

        //        _context.CarrinhoCompraItems.Add(carrinhoItem);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Index", "Carrinho");
        //    }

        //    return View(model);
        //}

        //public IActionResult Criar()
        //{
        //    // Lógica para carregar modelos e marcas disponíveis
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Criar(CapinhaPersonalizada capinha, IFormFile imagem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Salvar a imagem no servidor
        //        var imagePath = "path/para/armazenar/imagem";
        //        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //        {
        //            await imagem.CopyToAsync(fileStream);
        //        }

        //        // Salvar os dados da capinha personalizada no banco de dados
        //        capinha.ImagemPath = imagePath;
        //        _context.Add(capinha);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(capinha);
        //}











        public async Task<IActionResult> MinhasCapinhas(ClienteEPedidoViewModel clienteEPedidoViewModel) // Retornar todas as capinhas do usuário
        {
            var clienteExistente = _appDbContext.Clientes.SingleOrDefault(c => c.CPF == clienteEPedidoViewModel.CPF);

            Cliente cliente;
            if (clienteExistente == null)
            {
                cliente = new Cliente
                {
                    ClienteId = clienteEPedidoViewModel.ClienteId,
                    Nome = clienteEPedidoViewModel.Nome,
                    Sobrenome = clienteEPedidoViewModel.Sobrenome,
                    CPF = clienteEPedidoViewModel.CPF,
                    Telefone = clienteEPedidoViewModel.Telefone,
                    Email = clienteEPedidoViewModel.Email
                };
                _appDbContext.Clientes.Add(cliente);
                _appDbContext.SaveChanges();
            }
            else
            {
                cliente = clienteExistente;
                return RedirectToAction("Login", "Account");
            }
            var user = await _userManager.GetUserAsync(User);
            var capinhas = await _capinhaPersonalizadaRepository.GetCapinhasPersonalizadasByUserIdAsync(cliente.ClienteId);
            return View(capinhas);
        }
    }
}
