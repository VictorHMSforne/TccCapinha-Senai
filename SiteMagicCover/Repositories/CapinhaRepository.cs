using SiteMagicCover.Context;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SiteMagicCover.Repositories
{
    public class CapinhaRepository : ICapinhaRepository
    {
        private readonly AppDbContext _context;
        public CapinhaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }


        public IEnumerable<Capinha> Capinhas => _context.Capinhas.Include(c => c.Categoria);

        public Capinha GetCapinhaById(int capinhaId)
        {
            return _context.Capinhas.FirstOrDefault(c => c.CapinhaId == capinhaId);
        }


        //adicionei
        public IQueryable<Capinha> Capinhass => _context.Capinhas;

        public void DeleteCapinha(Capinha capinha)
        {
            _context.Capinhas.Remove(capinha);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
