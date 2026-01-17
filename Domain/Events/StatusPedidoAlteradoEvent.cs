using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Domain.Events
{
    public class StatusPedidoAlteradoEvent : INotification
    {
        private StatusPedido NovoStatusPedido {  get; init; }

        public StatusPedidoAlteradoEvent(StatusPedido statusPedido)
        {
            NovoStatusPedido = statusPedido;
        }
    }
}
