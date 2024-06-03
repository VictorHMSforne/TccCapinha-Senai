using SiteMagicCover.Models;

namespace SiteMagicCover.Repositories.Interfaces
{
    public interface ICapinhaPersonalizadaRepository
    {
        Task<CapinhaPersonalizada> GetCapinhaPersonalizadaByIdAsync(int id);
        Task<IEnumerable<CapinhaPersonalizada>> GetCapinhasPersonalizadasByUserIdAsync(int userId);
        Task AddCapinhaPersonalizadaAsync(CapinhaPersonalizada capinha);
        Task SaveChangesAsync();
    }
}
