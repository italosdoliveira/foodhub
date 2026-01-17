using Domain.Events;
using MediatR;

namespace Application.Handlers
{
    public class PedidoCriadoEventHandler : INotificationHandler<PedidoCriadoEvent>
    {
        public Task Handle(PedidoCriadoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
