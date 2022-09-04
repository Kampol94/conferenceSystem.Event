using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;

public class EventParticipantFeePaidDomainEvent : DomainEventBase
{
    public EventParticipantFeePaidDomainEvent(EventId eventId, MemberId participantId)
    {
        EventId = eventId;
        ParticipantId = participantId;
    }

    public EventId EventId { get; }

    public MemberId ParticipantId { get; }
}