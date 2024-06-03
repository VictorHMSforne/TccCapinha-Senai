using SiteMagicCover.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SiteMagicCover.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        //Toda vez que se cria um novo Modelo, é necessário adicionar aqui
        public DbSet<Categoria> Categorias { get; set; }// o EFC sabe que a partir da classe Categoria ele precisa criar uma tabela chamada Categorias
        public DbSet<Capinha> Capinhas { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CapinhaPersonalizada> CapinhasPersonalizadas { get; set; }
        public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }
        public DbSet<ClientePedido> ClientePedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.CapinhaPersonalizadas)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CapinhaPersonalizada>()
                .HasMany(p => p.ClientePedidos)
                .WithOne(cp => cp.CapinhaPersonalizada)
                .HasForeignKey(cp => cp.CapinhaPersoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CapinhaPersonalizada>()
                .HasMany(p => p.CarrinhoCompraItens)
                .WithOne(ci => ci.CapinhaPersonalizada)
                .HasForeignKey(ci => ci.CapinhaPersoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
