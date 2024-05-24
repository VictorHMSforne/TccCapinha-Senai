using SiteMagicCover.Models;

namespace SiteMagicCover.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }//propriedade somente Leitura por conta do Get
    }
}
