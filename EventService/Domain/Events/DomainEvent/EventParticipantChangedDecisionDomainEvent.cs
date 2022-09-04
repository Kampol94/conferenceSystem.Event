using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;
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
