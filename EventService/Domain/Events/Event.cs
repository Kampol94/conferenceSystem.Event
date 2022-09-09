using EventService.Domain.Contracts;
using EventService.Domain.EventReviews;
using EventService.Domain.Events.DomainEvent;
using EventService.Domain.Events.Rules;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.Events;

public class Event : BaseEntity
{
    public EventId Id { get; private set; }

    private readonly ExhibitionId _exhibitionId;

    public string Title { get; private set; }

    public EventTime Time { get; private set; }

    private string _description;

    private readonly List<EventParticipant> _participants;

    private readonly List<EventWaiteListMember> _waitlistMembers;

    private EventLimits _eventLimits;

    private RsvpTime _rsvpTime;

    private Money _eventFee;

    private readonly MemberId _creatorId;

    private readonly DateTime _createDate;

    private MemberId? _changeMemberId;

    private DateTime? _changeDate;

    private DateTime? _cancelDate;

    private MemberId? _cancelMemberId;

    private bool _isCanceled;

    //EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Event()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _participants = new List<EventParticipant>();
        _waitlistMembers = new List<EventWaiteListMember>();
    }

    public static Event CreateNew(
        ExhibitionId exhibitionId,
        string title,
        EventTime time,
        string description,
        EventLimits eventLimits,
        RsvpTime rsvpTime,
        Money eventFee,
        List<MemberId> hostsMembersIds,
        MemberId creatorId)
    {
        return new Event(
            exhibitionId,
            title,
            time,
            description,
            eventLimits,
            rsvpTime,
            eventFee,
            hostsMembersIds,
            creatorId);
    }

    private Event(
        ExhibitionId exhibitionId,
        string title,
        EventTime term,
        string description,
        EventLimits eventLimits,
        RsvpTime rsvpTerm,
        Money eventFee,
        List<MemberId> hostsMembersIds,
        MemberId creatorId)
    {
        Id = new EventId(Guid.NewGuid());
        _exhibitionId = exhibitionId;
        Title = title;
        Time = term;
        _description = description;
        _eventLimits = eventLimits;

        _rsvpTime = rsvpTerm;
        _eventFee = eventFee;
        _creatorId = creatorId;
        _createDate = DateTime.Now; //TODO: add time provider for test proposes 

        _participants = new List<EventParticipant>();
        _waitlistMembers = new List<EventWaiteListMember>();

        AddDomainEvent(new EventCreatedDomainEvent(Id));
        DateTime rsvpDate = DateTime.Now; //TODO: add time provider for test proposes 
        if (hostsMembersIds.Any())
        {
            foreach (MemberId hostMemberId in hostsMembersIds)
            {
                _participants.Add(EventParticipant.CreateNew(Id, hostMemberId, rsvpDate, EventParticipantRole.Host, Money.Undefined));
            }
        }
        else
        {
            _participants.Add(EventParticipant.CreateNew(Id, creatorId, rsvpDate, EventParticipantRole.Host, Money.Undefined));
        }
    }

    public void ChangeMainAttributes(
        string title,
        EventTime time,
        string description,
        EventLimits eventLimits,
        RsvpTime rsvpTerm,
        Money eventFee,
        MemberId modifyUserId)
    {
        CheckRule(new ParticipantsLimitCannotBeChangedToSmallerThanActiveParticipantsRule(
            eventLimits,
            GetAllActiveParticipansNumber()));

        Title = title;
        Time = time;
        _description = description;
        _eventLimits = eventLimits;
        _rsvpTime = rsvpTerm;
        _eventFee = eventFee;

        _changeDate = DateTime.Now; //TODO: add time provider for test proposes 
        _changeMemberId = modifyUserId;

        AddDomainEvent(new EventMainAttributesChangedDomainEvent(Id));
    }

    public void AddParticipant(Exhibition exhibition, MemberId participanId)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));

        CheckRule(new ParticipantCanBeAddedOnlyInRsvpTimeRule(_rsvpTime));

        CheckRule(new EventParticipantMustBeAMemberOfExhibitionRule(participanId, exhibition));

        CheckRule(new CannotAddParticipantMoreThenOnce(participanId, _participants));

        CheckRule(new EventParticipantsNumberIsAboveLimitRule(_eventLimits.ParticipantsLimit, GetAllActiveParticipansNumber()));

        _participants.Add(EventParticipant.CreateNew(
            Id,
            participanId,
            DateTime.Now, //TODO: add time provider for test proposes 
            EventParticipantRole.Participant,
            _eventFee));
    }

    public void SignUpMemberToWaitlist(Exhibition exhibition, MemberId memberId)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));

        CheckRule(new ParticipantCanBeAddedOnlyInRsvpTimeRule(_rsvpTime));

        CheckRule(new MemberOnWaitlistMustBeAMemberOfExhibitionRule(exhibition, memberId));

        CheckRule(new MemberCannotBeMoreThanOnceOnEventWaitlistRule(_waitlistMembers, memberId));

        _waitlistMembers.Add(EventWaiteListMember.CreateNew(Id, memberId));
    }

    public void SignOffMemberFromWaitlist(MemberId memberId)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));

        CheckRule(new NotActiveMemberOfWaitlistCannotBeSignedOffRule(_waitlistMembers, memberId));

        EventWaiteListMember memberOnWaitlist = GetActiveMemberOnWaitlist(memberId);

        memberOnWaitlist.SignOff();
    }

    public void SetHostRole(Exhibition exhibition, MemberId settingMemberId, MemberId newOrganizerId)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));

        CheckRule(new OnlyEventOrExhibitionOrganizerCanSetEventMemberRolesRule(settingMemberId, exhibition, _participants));

        CheckRule(new OnlyEventParticipantCanHaveChangedRoleRule(_participants, newOrganizerId));

        EventParticipant participant = GetActiveParicipant(newOrganizerId);

        participant.SetAsHost();
    }

    public void SetParticipantRole(Exhibition exhibition, MemberId settingMemberId, MemberId newOrganizerId)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));

        CheckRule(new OnlyEventOrExhibitionOrganizerCanSetEventMemberRolesRule(settingMemberId, exhibition, _participants));

        CheckRule(new OnlyEventParticipantCanHaveChangedRoleRule(_participants, newOrganizerId));

        EventParticipant participant = GetActiveParicipant(newOrganizerId);

        participant.SetAsParticipant();

        int eventHostNumber = _participants.Count(x => x.IsActiveHost());

        CheckRule(new EventMustHaveAtLeastOneHostRule(eventHostNumber));
    }

    public ExhibitionId GetExhibitionId()
    {
        return _exhibitionId;
    }

    public void Cancel(MemberId cancelMemberId)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));

        if (!_isCanceled)
        {
            _isCanceled = true;
            _cancelDate = DateTime.Now; //TODO: add time provider for test proposes 
            _cancelMemberId = cancelMemberId;

            AddDomainEvent(new EventCanceledDomainEvent(Id, _cancelMemberId, _cancelDate.Value));
        }
    }

    public void RemoveParticipant(MemberId participantId, MemberId removingPersonId, string reason)
    {
        CheckRule(new EventCannotBeChangedAfterStartRule(Time));
        CheckRule(new OnlyActiveParticipantCanBeRemovedFromEventRule(_participants, participantId));

        EventParticipant participant = GetActiveParicipant(participantId);

        participant.Remove(removingPersonId, reason);
    }

    public void MarkParticipantFeeAsPayed(MemberId memberId)
    {
        EventParticipant participant = GetActiveParicipant(memberId);

        participant.MarkFeeAsPayed();
    }

    public EventReview AddReview(MemberId authorId, string comment, Exhibition exhibition)
    {
        return EventReview.Create(
                Id,
                authorId,
                comment,
                exhibition);
    }

    private EventWaiteListMember GetActiveMemberOnWaitlist(MemberId memberId)
    {
        //TODO: not generic expetion 
        return _waitlistMembers.SingleOrDefault(x => x.IsActiveOnWaitList(memberId)) ?? throw new Exception();
    }

    private EventParticipant GetActiveParicipant(MemberId participantId)
    {
        //TODO: not generic expetion 
        return _participants.SingleOrDefault(x => x.IsActiveParticipant(participantId)) ?? throw new Exception();
    }

    private int GetAllActiveParticipansNumber()
    {
        return _participants.Where(x => x.IsActive()).Count();
    }
}
