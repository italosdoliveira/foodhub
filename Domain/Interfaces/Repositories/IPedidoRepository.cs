using Domain.Entities;
using Domain.Enums;
using MongoDB.Bson;

namespace Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> AdicionarPedido(Pedido pedido);
        Task<Pedido> AtualizarPedido(ObjectId id, Pedido pedido);
        Task<Pedido> AtualizarStatusPedido(ObjectId id, StatusPedido statusPedido);
        Task<bool> DeletarPedido(ObjectId id);
        Task<Pedido> BuscarPedidoPeloCodigo(string id);
        Task<IEnumerable<Pedido>> ListarPedido();
    }
}