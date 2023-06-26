using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_pedidos.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ControlePedidosDbContext _dbContext;

        public ProdutosRepository(ControlePedidosDbContext controlePedidosDbContext)
        {
            _dbContext = controlePedidosDbContext;
        }

        public async Task<List<ProdutosModel>> GetAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<ProdutosModel> GetById(int id)
        {
            ProdutosModel produto = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            return produto ?? throw new Exception("Produto não encontrado!");
        }

        public async Task<ProdutosModel> AddProduto(ProdutosModel produtos)
        {
            ProdutosModel produtoByName = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Nome == produtos.Nome);
            if (produtoByName == null)
            {
                await _dbContext.Produtos.AddAsync(produtos);
                await _dbContext.SaveChangesAsync();
                return produtos;
            }
            else
            {
                throw new Exception("Esse produto já existe!");
            }
            
        }

        public async Task<ProdutosModel> UpdateProduto(ProdutosModel produtos, int id)
        {
            ProdutosModel produtoById = await GetById(id);
            var temPedido = await _dbContext.ItensDePedido.FirstOrDefaultAsync(x => x.ProdutoId == produtoById.Id);
            if (temPedido != null)
            {
                throw new Exception("Este produto não pode ser alterado, pois pertence a um pedido!");
            }
            else
            {
                produtoById.Nome = produtos.Nome;
                produtoById.Categoria = produtos.Categoria;
            }

            _dbContext.Produtos.Update(produtoById);
            await _dbContext.SaveChangesAsync();

            return produtoById;
        }

        public async Task<string> DeleteById(int id)
        {
            ProdutosModel produtoById = await GetById(id);
            var temPedido = await _dbContext.ItensDePedido.FirstOrDefaultAsync(x => x.ProdutoId == id);

            if (temPedido != null)
            {
                throw new Exception("Este produto não pode ser excluido, pois pertence a um pedido!");
            }
            else 
            { 
                _dbContext.Produtos.Remove(produtoById);
                await _dbContext.SaveChangesAsync();
                return $"{produtoById.Nome} excluído com sucesso!";
            }
           
        }
    }
}
