using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Controle_de_pedidos.Controllers
{
    [Route("api/itens")]
    [ApiController]
    public class ItensDePedidoController : Controller
    {
        private readonly IItensDePedidoRepository _itensDePedidosRepository;

        public ItensDePedidoController(IItensDePedidoRepository iTensDePedidosRepository)
        {
            _itensDePedidosRepository = iTensDePedidosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItensDePedidoModel>>> GetAll()
        {
            List<ItensDePedidoModel> item = await _itensDePedidosRepository.GetAll();
            return Ok(item);
        }

        [HttpGet("{pedidoId}")]
        public async Task<ActionResult<List<ItensDePedidoModel>>> GetByPedidoId([BindRequired] int pedidoId)
        {
            try
            {
                List<ItensDePedidoModel> item = await _itensDePedidosRepository.GetByPedidoId(pedidoId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ItensDePedidoModel>> AddItem([FromBody] ItensDePedidoModel itemModel)
        {
            try
            {
                ItensDePedidoModel item = await _itensDePedidosRepository.AddItem(itemModel);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItensDePedidoModel>> DeleteItem([BindRequired] int id)
        {
            try
            {
                string deletedItem = await _itensDePedidosRepository.DeleteById(id);
                return Ok(deletedItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
