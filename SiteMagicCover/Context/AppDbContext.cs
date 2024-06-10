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

        public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }
        public DbSet<ClientePedido> ClientePedidos { get; set; }

       

    }
}
