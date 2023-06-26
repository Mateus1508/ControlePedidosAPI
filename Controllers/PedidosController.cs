using Controle_de_pedidos.Models;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Controle_de_pedidos.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosController(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository  = pedidosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosModel>>> GetAll()
        {
            List<PedidosModel> pedido = await _pedidosRepository.GetAll();
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PedidosModel>>> GetById([BindRequired] int id)
        {
            try
            {
                PedidosModel pedido = await _pedidosRepository.GetById(id);
                if (pedido == null)
                {
                    return NotFound("Pedido não encontrado.");
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PedidosModel>> AddPedido([FromBody] PedidosModel pedidoModel)
        {
            try
            {
                PedidosModel pedido = await _pedidosRepository.AddPedido(pedidoModel);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidosModel>> DeletePedido([BindRequired] int id)
        {
            try
            {
                string deletedPedido = await _pedidosRepository.DeleteById(id);
                return Ok(deletedPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
