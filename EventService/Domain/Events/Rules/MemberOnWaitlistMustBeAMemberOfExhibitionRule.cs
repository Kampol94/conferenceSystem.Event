using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class MemberOnWaitlistMustBeAMemberOfExhibitionRule : IBaseBusinessRule
{
    private readonly Exhibition _exhibition;

    private readonly MemberId _memberId;

    public MemberOnWaitlistMustBeAMemberOfExhibitionRule(Exhibition exhibition, MemberId memberId)
        : base()
    {
        _exhibition = exhibition;
        _memberId = memberId;
    }

    public bool IsBroken() => !_exhibition.IsMemberOfGroup(_memberId);

    public string Message => "Member on waitlist must be a member of group";
}