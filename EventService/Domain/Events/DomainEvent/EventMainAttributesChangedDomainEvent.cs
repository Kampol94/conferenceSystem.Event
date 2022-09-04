using EventService.Domain.Contracts;

namespace EventService.Domain.Events.DomainEvent;

public class EventMainAttributesChangedDomainEvent : DomainEventBase
{
    public EventMainAttributesChangedDomainEvent(EventId eventId)
    {
        EventId = eventId;
    }

    public EventId EventId { get; }
}