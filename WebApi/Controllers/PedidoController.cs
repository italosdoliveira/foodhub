using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDto>> Adicionar(Pedido pedido)
        {
            var pedidoAdicionado =  await _pedidoService.AdicionarPedido(pedido);
            return Ok(pedidoAdicionado);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<PedidoDto>> BuscarPorId(string codigo)
        {
            var pedido = await _pedidoService.BuscarPedidoPeloId(codigo);

            if (pedido == null)
                return NotFound();
            
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Listar()
        {
            var pedidos = await _pedidoService.ListarPedido();
            
            return Ok(pedidos);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<PedidoDto>> Atualizar(string codigo, [FromBody] AtualizacaoPedidoDto pedido)
        {
            var pedidoAtualizado = await _pedidoService.AtualizarPedido(codigo, pedido);
            
            if (pedidoAtualizado == null)
                return NotFound();
            
            return Ok(pedido);
        }

        [HttpPatch("{codigo}/status")]
        public async Task<ActionResult<PedidoDto>> AtualizarStatus(string codigo, [FromBody] string status)
        {
            //var pedido = await _pedidoService.AtualizarStatus(id, status);
            //if (pedido == null)
            //    return NotFound();
            
            return Ok(null);
        }
    }
}
