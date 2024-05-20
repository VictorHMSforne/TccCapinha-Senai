using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }// o EFC sabe que a partir da classe Categoria ele precisa criar uma tabela chamada Categorias
        public DbSet<Capinha> Capinhas { get; set; }
    }
}
