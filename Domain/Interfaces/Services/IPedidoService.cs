using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PedidoDto> AdicionarPedido(Pedido pedido);
        Task<PedidoDto> AtualizarPedido(string id, AtualizacaoPedidoDto pedido);
        Task<bool> DeletarPedido(string id);
        Task<PedidoDto> BuscarPedidoPeloId(string id);
        Task<IEnumerable<PedidoDto>> ListarPedido();
    }
}