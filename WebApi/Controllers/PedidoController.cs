using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebApi.Dtos;

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
            try
            {
                var pedidoAdicionado = await _pedidoService.AdicionarPedido(pedido);

                if (pedidoAdicionado == null)
                    return NotFound();

                return Ok(pedidoAdicionado);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpGet("buscar/{codigo}")]
        public async Task<ActionResult<PedidoDto>> BuscarPorCodigo(string codigo)
        {
            try
            {
                var pedido = await _pedidoService.BuscarPedidoPeloCodigo(codigo);

                if (pedido is null)
                    return NotFound();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Listar()
        {
            try
            {
                var pedidos = await _pedidoService.ListarPedido();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoDto>> Atualizar(ObjectId id, [FromBody] Pedido pedido)
        {
            try { 
                var pedidoAtualizado = await _pedidoService.AtualizarPedido(id, pedido);
            
                if (pedidoAtualizado == null)
                    return NotFound();
            
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
}

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<PedidoDto>> AtualizarStatus(ObjectId id, [FromBody] AtualizaStatusDto atualizaStatusDto)
        {
            try
            {
                var pedido = await _pedidoService.AtualizarStatusPedido(id, atualizaStatusDto.Status);
                if (pedido == null)
                    return NotFound();

                return Ok(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remover(ObjectId id)
        {
            try
            {
                var pedidoRemovido = await _pedidoService.DeletarPedido(id);

                if (!pedidoRemovido)
                    return NotFound();

                return Ok(pedidoRemovido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
