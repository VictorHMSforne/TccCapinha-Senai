using SiteMagicCover.Context;
using SiteMagicCover.Models;
using SiteMagicCover.Repositories.Interfaces;

namespace SiteMagicCover.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias; //revisar as aulas repository
    }
}
