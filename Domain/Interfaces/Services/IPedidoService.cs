using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;
using MongoDB.Bson;

namespace Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PedidoDto> AdicionarPedido(Pedido pedido);
        Task<PedidoDto> AtualizarPedido(ObjectId id, Pedido pedido);
        Task<PedidoDto> AtualizarStatusPedido(ObjectId id, StatusPedido novoStatus);
        Task<bool> DeletarPedido(ObjectId id);
        Task<PedidoDto> BuscarPedidoPeloCodigo(string codigo);
        Task<IEnumerable<PedidoDto>> ListarPedido();
    }
}