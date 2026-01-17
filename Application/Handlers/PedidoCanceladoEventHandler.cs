using Domain.Events;
using MediatR;

namespace Application.Handlers
{
    public class PedidoCanceladoEventHandler : INotificationHandler<Domain.Events.PedidoCanceladoEvent>
    {
        public Task Handle(PedidoCanceladoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
