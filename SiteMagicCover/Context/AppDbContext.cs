using SiteMagicCover.Models;
using Microsoft.EntityFrameworkCore;

namespace SiteMagicCover.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        //Toda vez que se cria um novo Modelo, é necessário adicionar aqui
        public DbSet<Categoria> Categorias { get; set; }// o EFC sabe que a partir da classe Categoria ele precisa criar uma tabela chamada Categorias
        public DbSet<Capinha> Capinhas { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
