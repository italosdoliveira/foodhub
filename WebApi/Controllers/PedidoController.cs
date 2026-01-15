using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace WebApi.Controllers
{
    [Route("pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDto>> Adicionar([FromBody] Pedido pedido)
        {
            var pedidoAdicionado =  await _pedidoService.AdicionarPedido(pedido);

            if (pedidoAdicionado == null)
                return NotFound();

            return Ok(pedidoAdicionado);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<PedidoDto>> BuscarPorCodigo(string codigo)
        {
            var pedido = await _pedidoService.BuscarPedidoPeloCodigo(codigo);

            if (pedido is null)
                return NotFound();
            
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Listar()
        {
            var pedidos = await _pedidoService.ListarPedido();
            
            return Ok(pedidos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoDto>> Atualizar(ObjectId id, [FromBody] Pedido pedido)
        {
            var pedidoAtualizado = await _pedidoService.AtualizarPedido(id, pedido);
            
            if (pedidoAtualizado == null)
                return NotFound();
            
            return Ok(pedido);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<PedidoDto>> AtualizarStatus(ObjectId id, [FromBody] string status)
        {
            //var pedido = await _pedidoService.AtualizarStatus(id, status);
            //if (pedido == null)
            //    return NotFound();
            
            return Ok(null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(ObjectId id)
        {
            var pedidoRemovido = await _pedidoService.DeletarPedido(id);
            
            if (!pedidoRemovido)
                return NotFound();
            
            return Ok(pedidoRemovido);
        }
    }
}
