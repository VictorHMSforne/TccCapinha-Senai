using Microsoft.EntityFrameworkCore;
using SiteMagicCover.Context;

namespace SiteMagicCover.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Define uma Sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // esse ? se chama operador Elvis

            //Obtem um serviçõ do tipo do Contexto
            var context = services.GetService<AppDbContext>();
            //Obtem ou gera o Id do Carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o Id do carrinho na Sessão
            session.SetString("CarrinhoId",carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuído ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Capinha capinha)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.
                SingleOrDefault(s => s.Capinha.CapinhaId == capinha.CapinhaId && s.CarrinhoCompraId == CarrinhoCompraId); // verifica se essa capinha existe e se existir obtem o Id

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Capinha = capinha,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public void AdicionarAoCarrinhoPerso(Capinha capinha, bool isPersonalizada)
        {
            
            capinha.IsPersonalizada = isPersonalizada;

            var carrinhoCompraItem = _context.CarrinhoCompraItens
                .SingleOrDefault(s => s.Capinha.CapinhaId == capinha.CapinhaId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Capinha = capinha,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _context.SaveChanges();
        }


        public int RemoverDoCarrinho(Capinha capinha) //pode deixar esse método como void em vez de int, ai nao precisaria da var quantidadelocal e nem do return
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.
               SingleOrDefault(s => s.Capinha.CapinhaId == capinha.CapinhaId && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Capinha)
                .ToList()); /* esse ?? se chama operador de coalescência nula, ele funciona assim: se existir algo e não for null, ele vai usar o return, se não
                            ele vai criar esse código e usá-lo*/
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId); 
            
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens); //remove todas as entidades do carrinho referente ao Id informado
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId) // ele procura um carrinho especifico e vai selecionar e logo depois fazer o cálculo
                .Select(c => Convert.ToDecimal(c.Capinha.Preco) * c.Quantidade).Sum(); //VIR AQUI SE DER ERRO COM NUMEROS DO CARRINHO, E VERIFICAR SE VAI DAR CONFLITO DEPOIS NO BD

            return total;
        }
    }
}
