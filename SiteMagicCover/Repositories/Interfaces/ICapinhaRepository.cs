using SiteMagicCover.Models;

namespace SiteMagicCover.Repositories.Interfaces
{
    public interface ICapinhaRepository
    {
        IEnumerable<Capinha> Capinhas { get; } //propriedade somente leitura
        Capinha GetCapinhaById(int capinhaId);
    }
}
