using SiteMagicCover.Models;

namespace SiteMagicCover.ViewModels
{
    public class CapinhaListViewModel
    {
        public IEnumerable<Capinha> Capinhas { get; set; } // prop para exibir uma lista de capinhas
        public string CategoriaAtual { get; set; } // As categorias que quero exibir
    }
}
