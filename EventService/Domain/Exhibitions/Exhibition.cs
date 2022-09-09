using EventService.Domain.Contracts;
using EventService.Domain.Events;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Exhibitions.Events;
using EventService.Domain.Exhibitions.Rules;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions;

public class Exhibition : BaseEntity
{
    public ExhibitionId Id { get; private set; }

    public string Name { get; private set; }

    private string _description;

    public MemberId CreatorId { get; private set; }

    private List<ExhibitionMember> _members;

    private DateTime _createDate;

    private DateTime? _paymentDateTo;

    public static Exhibition CreateBasedOnProposal(
        ExhibitionProposalId exhibitionProposalId,
        string name,
        string description,
        MemberId creatorId)
    {
        return new Exhibition(exhibitionProposalId, name, description, creatorId);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Exhibition()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    private Exhibition(ExhibitionProposalId exhibitionProposalId, string name, string description, MemberId creatorId)
    {
        Id = new ExhibitionId(exhibitionProposalId.Value);
        Name = name;
        _description = description;
        CreatorId = creatorId;
        _createDate = DateTime.Now;

        this.AddDomainEvent(new ExhibitionCreatedDomainEvent(Id, creatorId));

        _members = new List<ExhibitionMember>();
        _members.Add(ExhibitionMember.CreateNew(Id, CreatorId, ExhibitionMemberRole.Organizer));
    }

    public void EditGeneralAttributes(string name, string description)
    {
        Name = name;
        _description = description;

        this.AddDomainEvent(new ExhibitionGeneralAttributesEditedDomainEvent(Name, _description));
    }

    public void AddMember(MemberId memberId)
    {
        CheckRule(new ExhibitionMemberCannotBeAddedTwiceRule(_members, memberId));

        _members.Add(ExhibitionMember.CreateNew(Id, memberId, ExhibitionMemberRole.Member));
    }

    public void LeaveGroup(MemberId memberId)
    {
        CheckRule(new NotActualExhibitionMemberCannotLeaveGroupRule(_members, memberId));

        var member = _members.Single(x => x.IsMember(memberId));

        member.Leave();
    }

    public void SetExpirationDate(DateTime dateTo)
    {
        _paymentDateTo = dateTo;

        this.AddDomainEvent(new ExhibitionPaymentInfoUpdatedDomainEvent(Id, _paymentDateTo.Value));
    }

    public Event CreateEvent(
        string title,
        EventTime eventTime,
        string description,
        int? attendeesLimit,
        RsvpTime rsvpTime,
        Money eventFee,
        List<MemberId> hostsMembersIds,
        MemberId creatorId)
    {
        CheckRule(new EventCanBeOrganizedOnlyByPayedExhibitionRule(_paymentDateTo));

        CheckRule(new EventHostMustBeAExhibitionMemberRule(creatorId, hostsMembersIds, _members));

        return Event.CreateNew(
            Id,
            title,
            eventTime,
            description,
            EventLimits.Create(attendeesLimit),
            rsvpTime,
            eventFee,
            hostsMembersIds,
            creatorId);
    }

    public bool IsMemberOfGroup(MemberId attendeeId)
    {
        return _members.Any(x => x.IsMember(attendeeId));
    }

    public bool IsOrganizer(MemberId memberId)
    {
        return _members.Any(x => x.IsOrganizer(memberId));
    }
}