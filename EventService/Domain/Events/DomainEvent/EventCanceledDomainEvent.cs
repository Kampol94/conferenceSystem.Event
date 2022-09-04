using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;

public class EventCanceledDomainEvent : DomainEventBase
{
    public EventCanceledDomainEvent(EventId eventId, MemberId cancelMemberId, DateTime cancelDate)
    {
        EventId = eventId;
        CancelMemberId = cancelMemberId;
        CancelDate = cancelDate;
    }

    public EventId EventId { get; }

    public MemberId CancelMemberId { get; }

    public DateTime CancelDate { get; }
}