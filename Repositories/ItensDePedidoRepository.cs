using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_pedidos.Repositories
{
    public class ItensDePedidoRepository : IItensDePedidoRepository
    {
        private readonly ControlePedidosDbContext _dbContext;

        public ItensDePedidoRepository(ControlePedidosDbContext controlePedidosDbContext)
        {
            _dbContext = controlePedidosDbContext;
        }

        public async Task<List<ItensDePedidoModel>> GetAll()
        {
            return await _dbContext.ItensDePedido.ToListAsync();
        }

        public async Task<List<ItensDePedidoModel>> GetByPedidoId(int pedidoId)
        {
            List<ItensDePedidoModel> itens = await _dbContext.ItensDePedido.Include(x => x.Produto).Where(x => x.PedidoId == pedidoId).ToListAsync();
            return itens ?? throw new Exception("Pedido não encontrado!");
        }

        public async Task<ItensDePedidoModel> GetById(int id)
        {
            ItensDePedidoModel item = await _dbContext.ItensDePedido.FirstOrDefaultAsync(x => x.Id == id);
            return item ?? throw new Exception("Item não encontrado!");
        }

        public async Task<ItensDePedidoModel> AddItem(ItensDePedidoModel item)
        {
            item.Valor *= item.Quantidade;

            var hasPedido = await _dbContext.ItensDePedido.FirstOrDefaultAsync(x => x.PedidoId == item.PedidoId && x.ProdutoId == item.ProdutoId);
            if (hasPedido != null)
            {
                throw new Exception("Este produto já foi pedido!");
            }

            var produtoById = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == item.ProdutoId) ?? throw new Exception("Produto não encontrado!");

            var PedidoById = await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == item.PedidoId);
            if (PedidoById != null)
            {
                PedidoById.ValorTotal += item.Valor;
            }
            else
            {
                throw new Exception("Pedido não encontrado!");
            }

            await _dbContext.ItensDePedido.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<string> DeleteById(int id)
        {
            ItensDePedidoModel itemById = await GetById(id);

            _dbContext.ItensDePedido.Remove(itemById);
            await _dbContext.SaveChangesAsync();
            return "Item excluido com sucesso!";
        }
    }
}
