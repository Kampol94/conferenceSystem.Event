using EventService.Domain.Contracts;
using EventService.Domain.Events.DomainEvent;
using EventService.Domain.Members;

namespace EventService.Domain.Events;

public class EventWaiteListMember : BaseEntity
{
    public MemberId MemberId { get; private set; }

    public EventId EventId { get; private set; }

    public DateTime SignUpDate { get; private set; }

    private bool _isSignedOff;

    private DateTime? _signOffDate;

    private bool _isMovedToParticipants;

    private DateTime? _movedToParticipantsDate;

    //EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EventWaiteListMember()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    private EventWaiteListMember(EventId eventId, MemberId memberId)
    {
        MemberId = memberId;
        EventId = eventId;
        SignUpDate = DateTime.Now; //TODO: add time provider for test proposes 
        _isMovedToParticipants = false;

        AddDomainEvent(new EventWaitlistMemberAddedDomainEvent(EventId, MemberId));
    }

    public static EventWaiteListMember CreateNew(EventId eventId, MemberId memberId)
    {
        return new EventWaiteListMember(eventId, memberId);
    }

    public void MarkIsMovedToParticipants()
    {
        _isMovedToParticipants = true;
        _movedToParticipantsDate = DateTime.Now; //TODO: add time provider for test proposes 
    }

    public bool IsActiveOnWaitList(MemberId memberId)
    {
        return MemberId == memberId && IsActive();
    }

    public bool IsActive()
    {
        return !_isSignedOff && !_isMovedToParticipants;
    }

    public void SignOff()
    {
        _isSignedOff = true;
        _signOffDate = DateTime.Now; //TODO: add time provider for test proposes 

        AddDomainEvent(new MemberSignedOffFromEventWaitlistDomainEvent(EventId, MemberId));
    }
}