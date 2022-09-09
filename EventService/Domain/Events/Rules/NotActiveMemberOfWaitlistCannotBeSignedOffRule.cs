using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class NotActiveMemberOfWaitlistCannotBeSignedOffRule : IBaseBusinessRule
{
    private readonly List<EventWaiteListMember> _waitlistMembers;

    private readonly MemberId _memberId;

    public NotActiveMemberOfWaitlistCannotBeSignedOffRule(List<EventWaiteListMember> waitlistMembers, MemberId memberId)
    {
        _waitlistMembers = waitlistMembers;
        _memberId = memberId;
    }

    public bool IsBroken() => _waitlistMembers.SingleOrDefault(x => x.IsActiveOnWaitList(_memberId)) == null;

    public string Message => "Not active member of waitlist cannot be signed off";
}