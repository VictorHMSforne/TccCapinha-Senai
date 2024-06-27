using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SiteMagicCover.Models;

namespace SiteMagicCover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _configurationImagens;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminImagensController(IOptions<ConfigurationImagens> configurationImagens, 
                                      IWebHostEnvironment webHostEnvironment)
        {
            _configurationImagens = configurationImagens.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
