using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Rules;

public class ExhibitionMemberCannotBeAddedTwiceRule : IBaseBusinessRule
{
    private readonly List<ExhibitionMember> _members;

    private readonly MemberId _memberId;

    public ExhibitionMemberCannotBeAddedTwiceRule(List<ExhibitionMember> members, MemberId memberId)
        : base()
    {
        _members = members;
        _memberId = memberId;
    }

    public bool IsBroken() => _members.SingleOrDefault(x => x.IsMember(_memberId)) != null;

    public string Message => "Member cannot be added twice to the same exhibition";
}