using MediatR;
using MongoDB.Bson;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public ObjectId Id { get; set; }
        public List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem) {             
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents() {
            _domainEvents?.Clear();
        }
    }
}
