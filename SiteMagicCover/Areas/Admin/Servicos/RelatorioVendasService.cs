using Microsoft.EntityFrameworkCore;
using SiteMagicCover.Context;
using SiteMagicCover.Models;

namespace SiteMagicCover.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _appDbContext;

        public RelatorioVendasService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<ClientePedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _appDbContext.ClientePedidos select obj; // Consulta LINQ
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }
            return await resultado
                        .Include(p => p.Capinha) // Inclui a entidade Capinha
                        .Include(p => p.Cliente) // Inclui a entidade Cliente
                        .OrderByDescending(x => x.PedidoEnviado)
                        .ToListAsync();
        }
    }
}
