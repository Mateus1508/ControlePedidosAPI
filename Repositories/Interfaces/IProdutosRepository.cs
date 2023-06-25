using Controle_de_pedidos.Models;

namespace Controle_de_pedidos.Repositories.Interfaces
{
    public interface IProdutosRepository
    {
        Task<List<ProdutosModel>> GetAll();

        Task<ProdutosModel> GetById(int id);

        Task<ProdutosModel> AddProduto(ProdutosModel produtos);

        Task<ProdutosModel> UpdateProduto(ProdutosModel produtos, int id);

        Task<string> DeleteById(int id);
    }
}
