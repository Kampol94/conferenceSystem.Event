using EventService.Domain.Contracts;
using EventService.Domain.EventGroups;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class MemberOnWaitlistMustBeAMemberOfGroupRule : IBaseBusinessRule
{
    private readonly ConferenceGroups _eventGroup;

    private readonly MemberId _memberId;

    internal MemberOnWaitlistMustBeAMemberOfGroupRule(ConferenceGroups eventGroup, MemberId memberId)
        : base()
    {
        _eventGroup = eventGroup;
        _memberId = memberId;
    }

    public bool IsBroken() => !_eventGroup.IsMemberOfGroup(_memberId);

    public string Message => "Member on waitlist must be a member of group";
}