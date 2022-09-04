using EventService.Domain.Contracts;
using EventService.Domain.Events;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Events;

public class EventParticipantChangedDecisionDomainEvent : DomainEventBase
{
    public EventParticipantChangedDecisionDomainEvent(MemberId memberId, EventId eventId)
    {
        MemberId = memberId;
        EventId = eventId;
    }

    public MemberId MemberId { get; }

    public EventId EventId { get; }
}