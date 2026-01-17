using Domain.Entities;
using MediatR;

namespace Domain.Events
{
    public class PedidoAtualizadoEvent : INotification
    {
        public Pedido Pedido { get; init; }

        public PedidoAtualizadoEvent(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
