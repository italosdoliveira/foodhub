using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MongoDB.Bson;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> AdicionarPedido(Pedido pedido)
        {
            try
            {
                pedido.CalcularTotalPedido();
                var pedidoAdicionado = await _pedidoRepository.AdicionarPedido(pedido);
                return new PedidoDto(pedidoAdicionado);
            }
            catch (Exception ex) {
                return null;
            }
        }

        public async Task<PedidoDto> AtualizarPedido(ObjectId id, Pedido pedido)
        {
            try
            {
                var pedidoAtualizado = await _pedidoRepository.AtualizarPedido(pedido);

                return new PedidoDto(pedidoAtualizado);
            }
            catch
            {
                return null;
            }
        }


        public async Task<PedidoDto> BuscarPedidoPeloCodigo(string codigo)
        {
            try
            {
                var pedido = await _pedidoRepository.BuscarPedidoPeloCodigo(codigo);

                if (pedido is null)
                    return null;

                return new PedidoDto(pedido);
            }
            catch 
            {
                return null;
            }
            
        }

        public async Task<bool> DeletarPedido(ObjectId id)
        {
            try
            {
                return await _pedidoRepository.DeletarPedido(id);
            }
            catch
            { 
                return false; 
            }
        }

        public async Task<IEnumerable<PedidoDto>> ListarPedido()
        {
            try
            {
                var pedidos = await _pedidoRepository.ListarPedido();

                if (pedidos is null)
                    return null;

                return pedidos.Select(p => new PedidoDto(p)).AsEnumerable();
            }
            catch
            {
                return null;
            }
        }
    }
}
