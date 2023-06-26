using Controle_de_pedidos.Models;

namespace Controle_de_pedidos.Repositories.Interfaces
{
    public interface IItensDePedidoRepository
    {
        Task<List<ItensDePedidoModel>> GetAll();

        Task<ItensDePedidoModel> GetById(int id);

        Task<List<ItensDePedidoModel>> GetByPedidoId(int pedidoId);

        Task<ItensDePedidoModel> AddItem(ItensDePedidoModel item);

        Task<string> DeleteById(int id);
    }
}
