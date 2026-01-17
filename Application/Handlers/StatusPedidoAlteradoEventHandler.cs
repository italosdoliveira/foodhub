using Domain.Events;
using MediatR;

namespace Application.Handlers
{
    public class StatusPedidoAlteradoEventHandler : INotificationHandler<Domain.Events.StatusPedidoAlteradoEvent>
    {
        public Task Handle(StatusPedidoAlteradoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
