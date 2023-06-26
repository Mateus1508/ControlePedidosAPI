using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Controle_de_pedidos.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> GetAll()
        {
            List<ProdutosModel> produtos = await _produtosRepository.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutosModel>>> GetById([BindRequired] int id)
        {
            try
            {
                ProdutosModel produto = await _produtosRepository.GetById(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> AddProduto([FromBody] ProdutosModel pessoaModel)
        {
            try
            {
                ProdutosModel produto = await _produtosRepository.AddProduto(pessoaModel);
                return Ok(produto.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> UpdateProduto([FromBody] ProdutosModel pessoaModel, int id)
        {
            try
            {
                pessoaModel.Id = id;
                ProdutosModel produto = await _produtosRepository.UpdateProduto(pessoaModel, id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutosModel>> DeleteProduto([BindRequired] int id)
        {
            try
            {
                string deletedProduto = await _produtosRepository.DeleteById(id);
                return Ok(deletedProduto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
