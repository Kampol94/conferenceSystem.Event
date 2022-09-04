using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;

public class EventParticipantRemovedDomainEvent : DomainEventBase
{
    public EventParticipantRemovedDomainEvent(MemberId memberId, EventId eventId, string reason)
    {
        MemberId = memberId;
        EventId = eventId;
        Reason = reason;
    }

    public MemberId MemberId { get; }

    public EventId EventId { get; }

    public string Reason { get; }
}