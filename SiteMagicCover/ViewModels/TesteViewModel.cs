using Microsoft.AspNetCore.Mvc.Rendering;

namespace SiteMagicCover.ViewModels
{
    public class TesteViewModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public List<SelectListItem> Marcas { get; set; }
        public List<SelectListItem> Modelos { get; set; }
    }
}
