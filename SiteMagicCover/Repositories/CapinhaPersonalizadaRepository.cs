using Microsoft.EntityFrameworkCore;
using SiteMagicCover.Context;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories.Interfaces;

namespace SiteMagicCover.Repositories
{
    public class CapinhaPersonalizadaRepository : ICapinhaPersonalizadaRepository
    {
        private readonly AppDbContext _context;

        public CapinhaPersonalizadaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CapinhaPersonalizada> GetCapinhaPersonalizadaByIdAsync(int id)
        {
            return await _context.CapinhasPersonalizadas.FindAsync(id);
        }

        public async Task<IEnumerable<CapinhaPersonalizada>> GetCapinhasPersonalizadasByUserIdAsync(int userId)
        {
            return await _context.CapinhasPersonalizadas.Where(c => c.ClienteId == userId).ToListAsync();
        }

        public async Task AddCapinhaPersonalizadaAsync(CapinhaPersonalizada capinha)
        {
            await _context.CapinhasPersonalizadas.AddAsync(capinha);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
