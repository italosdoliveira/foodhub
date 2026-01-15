using Domain.Dtos;
using Domain.Entities;
using MongoDB.Bson;

namespace Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PedidoDto> AdicionarPedido(Pedido pedido);
        Task<PedidoDto> AtualizarPedido(ObjectId id, Pedido pedido);
        Task<bool> DeletarPedido(ObjectId id);
        Task<PedidoDto> BuscarPedidoPeloCodigo(string codigo);
        Task<IEnumerable<PedidoDto>> ListarPedido();
    }
}