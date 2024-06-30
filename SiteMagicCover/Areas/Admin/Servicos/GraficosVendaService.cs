using SiteMagicCover.Context;
using SiteMagicCover.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMagicCover.Areas.Admin.Servicos
{
    public class GraficosVendaService
    {
        private readonly AppDbContext context;

        public GraficosVendaService(AppDbContext context)
        {
            this.context = context;
        }

        public List<CapinhaGrafico> GetVendasCapinhas(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var capinhas = (from cp in context.ClientePedidos
                            join c in context.Capinhas on cp.CapinhaId equals c.CapinhaId
                            where cp.PedidoEnviado >= data
                            group cp by new { cp.CapinhaId, c.NomeCelular }
                            into g
                            select new
                            {
                                CapinhaNome = g.Key.NomeCelular,
                                CapinhasQuantidade = g.Sum(q => q.Quantidade),
                                CapinhasValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                            });

            var lista = new List<CapinhaGrafico>();
            foreach (var item in capinhas)
            {
                var capinha = new CapinhaGrafico();
                capinha.CapinhaNome = item.CapinhaNome;
                capinha.CapinhasQuantidae = item.CapinhasQuantidade;
                capinha.CapinhasValorTotal = item.CapinhasValorTotal;
                lista.Add(capinha);
            }
            return lista;
        }
    }
}
