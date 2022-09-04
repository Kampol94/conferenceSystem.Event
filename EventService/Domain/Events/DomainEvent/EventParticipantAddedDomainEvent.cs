using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;

public class EventParticipantAddedDomainEvent : DomainEventBase
{
    public EventParticipantAddedDomainEvent(
        EventId eventId,
        MemberId participantId,
        DateTime rsvpDate,
        string role,
        decimal? feeValue,
        string? feeCurrency)
    {
        EventId = eventId;
        ParticipantId = participantId;
        RSVPDate = rsvpDate;
        Role = role;
        FeeValue = feeValue;
        FeeCurrency = feeCurrency;
    }

    public EventId EventId { get; }

    public MemberId ParticipantId { get; }

    public DateTime RSVPDate { get; }

    public string Role { get; }

    public decimal? FeeValue { get; }

    public string? FeeCurrency { get; }
}