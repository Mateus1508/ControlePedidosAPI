using Controle_de_pedidos.Models;

namespace Controle_de_pedidos.Repositories.Interfaces
{
    public interface IPedidosRepository
    {
        Task<List<PedidosModel>> GetAll();

        Task<PedidosModel> GetById(int id);

        Task<PedidosModel> AddPedido(PedidosModel pedidos);

        Task<string> DeleteById(int id);
    }
}
