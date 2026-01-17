using Domain.Events;
using MediatR;

namespace Application.Handlers
{
    public class ItemRemovidoEventHandler : INotificationHandler<ItemRemovidoEvent>
    {
        public Task Handle(ItemRemovidoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
