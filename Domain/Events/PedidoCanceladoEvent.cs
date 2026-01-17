using Domain.Entities;
using MediatR;

namespace Domain.Events
{
    public class PedidoCanceladoEvent : INotification
    {
        private Pedido Pedido {  get; init; }

        public PedidoCanceladoEvent(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
