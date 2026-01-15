using Domain.Entities;
using MongoDB.Bson;

namespace Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> AdicionarPedido(Pedido pedido);
        Task<Pedido> AtualizarPedido(Pedido pedido);
        Task<bool> DeletarPedido(ObjectId id);
        Task<Pedido> BuscarPedidoPeloCodigo(string id);
        Task<IEnumerable<Pedido>> ListarPedido();
    }
}