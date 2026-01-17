using Domain.Events;
using MediatR;

namespace Application.Handlers
{
    public class PedidoAtualizadoEventHandler : INotificationHandler<PedidoAtualizadoEvent>
    {
        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
