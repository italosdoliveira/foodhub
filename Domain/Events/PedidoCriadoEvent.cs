using Domain.Entities;
using MediatR;

namespace Domain.Events
{
    public class PedidoCriadoEvent : INotification
    {
        public Pedido Pedido { get; init; }

        public PedidoCriadoEvent(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
