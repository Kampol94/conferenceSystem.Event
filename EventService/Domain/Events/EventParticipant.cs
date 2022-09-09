using EventService.Domain.Contracts;
using EventService.Domain.Events.DomainEvent;
using EventService.Domain.Events.Rules;
using EventService.Domain.Members;

namespace EventService.Domain.Events;

public class EventParticipant : BaseEntity
{
    public MemberId ParticipantId { get; private set; }

    public EventId EventId { get; private set; }

    private readonly DateTime _decisionDate;

    private EventParticipantRole _role;

    private bool _decisionChanged;

    private DateTime? _decisionChangeDate;

    private DateTime? _removedDate;

    private MemberId? _removingMemberId;

    private string? _removingReason;

    private bool _isRemoved;

    private readonly Money _fee;

    private bool _isFeePaid;

    //EF required 
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EventParticipant()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public static EventParticipant CreateNew(
        EventId eventId,
        MemberId participantId,
        DateTime decisionDate,
        EventParticipantRole role,
        Money eventFee)
    {
        return new EventParticipant(eventId, participantId, decisionDate, role, eventFee);
    }

    private EventParticipant(
        EventId eventId,
        MemberId participantId,
        DateTime decisionDate,
        EventParticipantRole role,
        Money eventFee)
    {
        ParticipantId = participantId;
        EventId = eventId;
        _decisionDate = decisionDate;
        _role = role;
        _decisionChanged = false;
        _isFeePaid = false;
        _fee = eventFee;



        AddDomainEvent(new EventParticipantAddedDomainEvent(
            EventId,
            ParticipantId,
            decisionDate,
            role.Value,
            _fee.Value,
            _fee.Currency));
    }

    public void ChangeDecision()
    {
        _decisionChanged = true;
        _decisionChangeDate = DateTime.Now; //TODO: add time provider for test proposes 

        AddDomainEvent(new EventParticipantChangedDecisionDomainEvent(ParticipantId, EventId));
    }

    public bool IsActiveParticipant(MemberId participantId)
    {
        return ParticipantId == participantId && !_decisionChanged;
    }

    public bool IsActive()
    {
        return !_decisionChangeDate.HasValue && !_isRemoved;
    }

    public bool IsActiveHost()
    {
        return IsActive() && _role == EventParticipantRole.Host;
    }

    public void SetAsHost()
    {
        _role = EventParticipantRole.Host;

        AddDomainEvent(new NewEventHostSetDomainEvent(EventId, ParticipantId));
    }

    public void SetAsParticipant()
    {
        _role = EventParticipantRole.Participant;

        AddDomainEvent(new MemberSetAsParticipantDomainEvent(EventId, ParticipantId));
    }

    public void Remove(MemberId removingMemberId, string reason)
    {
        CheckRule(new ReasonOfRemovingParticipantFromEventMustBeProvidedRule(reason));

        _isRemoved = true;
        _removedDate = DateTime.Now; //TODO: add time provider for test proposes 
        _removingReason = reason;
        _removingMemberId = removingMemberId;

        AddDomainEvent(new EventParticipantRemovedDomainEvent(ParticipantId, EventId, reason));
    }

    public void MarkFeeAsPayed()
    {
        _isFeePaid = true;

        AddDomainEvent(new EventParticipantFeePaidDomainEvent(EventId, ParticipantId));
    }
}