using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Rules;

public class NotActualExhibitionMemberCannotLeaveGroupRule : IBaseBusinessRule
{
    private readonly List<ExhibitionMember> _members;

    private readonly MemberId memberId;

    public NotActualExhibitionMemberCannotLeaveGroupRule(List<ExhibitionMember> members, MemberId memberId)
        : base()
    {
        _members = members;
        this.memberId = memberId;
    }

    public bool IsBroken() => _members.SingleOrDefault(x => x.IsMember(memberId)) == null;

    public string Message => "Member is not member of this exhibitio so he cannot leave it";
}