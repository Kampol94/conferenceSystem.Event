using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;

public class NewEventHostSetDomainEvent : DomainEventBase
{
    public NewEventHostSetDomainEvent(EventId eventId, MemberId hostId)
    {
        EventId = eventId;
        HostId = hostId;
    }

    public EventId EventId { get; }

    public MemberId HostId { get; }
}