using EventService.Domain.Contracts;
using EventService.Domain.Contracts.Events;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class MemberCannotBeMoreThanOnceOnEventWaitlistRule : IBaseBusinessRule
{
    private readonly List<EventWaitlistMember> _waitListMembers;

    private readonly MemberId _memberId;

    internal MemberCannotBeMoreThanOnceOnEventWaitlistRule(List<EventWaitlistMember> waitListMembers, MemberId memberId)
    {
        _waitListMembers = waitListMembers;
        _memberId = memberId;
    }

    public bool IsBroken() => _waitListMembers.SingleOrDefault(x => x.IsActiveOnWaitList(_memberId)) != null;

    public string Message => "Member cannot be more than once on the event waitlist";
}