using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> AdicionarPedido(Pedido pedido);
        Task<Pedido> AtualizarPedido(Pedido pedido);
        Task<bool> DeletarPedido(string id);
        Task<Pedido> BuscarPedidoPeloId(string id);
        Task<IEnumerable<Pedido>> ListarPedido();
    }
}