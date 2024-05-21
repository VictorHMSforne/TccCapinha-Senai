using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICapinhaRepository
    {
        IEnumerable<Capinha> Capinhas { get; } //propriedade somente leitura
        Capinha GetCapinhaById(int capinhaId);
    }
}
