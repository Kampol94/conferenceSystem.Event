using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Rules;

public class EventHostMustBeAExhibitionMemberRule : IBaseBusinessRule
{
    private readonly MemberId _creatorId;

    private readonly List<MemberId> _hostsMembersIds;

    private readonly List<ExhibitionMember> _members;

    public EventHostMustBeAExhibitionMemberRule(
        MemberId creatorId,
        List<MemberId> hostsMembersIds,
        List<ExhibitionMember> members)
    {
        _creatorId = creatorId;
        _hostsMembersIds = hostsMembersIds;
        _members = members;
    }

    public bool IsBroken()
    {
        List<MemberId> memberIds = _members.Select(x => x.MemberId).ToList();
        return (!_hostsMembersIds.Any() && !memberIds.Contains(_creatorId))
|| (_hostsMembersIds.Any() && _hostsMembersIds.Except(memberIds).Any());
    }

    public string Message => "Meeting host must be a exhibition member";
}