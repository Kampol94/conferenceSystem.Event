using EventService.Domain.Contracts;

namespace EventService.Domain.Events.DomainEvent;

public class EventCreatedDomainEvent : DomainEventBase
{
    public EventCreatedDomainEvent(EventId eventId)
    {
        EventId = eventId;
    }

    public EventId EventId { get; }
}