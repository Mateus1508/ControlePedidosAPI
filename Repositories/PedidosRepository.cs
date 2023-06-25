using Controle_de_pedidos.Helpers;
using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_pedidos.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly ControlePedidosDbContext _dbContext;

        public PedidosRepository(ControlePedidosDbContext controlePedidosDbContext)
        {
            _dbContext = controlePedidosDbContext;
        }

        public async Task<List<PedidosModel>> GetAll()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<PedidosModel> GetById(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PedidosModel> AddPedido(PedidosModel pedidos)
        {
            pedidos.Identificador = IdentificadorHelper.GetNextPatternValue();
            pedidos.ValorTotal = 0;
            await _dbContext.Pedidos.AddAsync(pedidos);
            await _dbContext.SaveChangesAsync();
            return pedidos;
        }

        public async Task<string> DeleteById(int id)
        {
            PedidosModel pedidoById = await GetById(id) ?? throw new Exception("Pedido não encontrado!");

            _dbContext.Pedidos.Remove(pedidoById);
            await _dbContext.SaveChangesAsync();
            return "Pedido excluído com sucesso!";
        }
    }
}
