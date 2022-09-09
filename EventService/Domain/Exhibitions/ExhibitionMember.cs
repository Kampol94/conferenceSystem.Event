using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions.Events;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions;

public class ExhibitionMember : BaseEntity
{
    public ExhibitionId ExhibitionId { get; private set; }

    public MemberId MemberId { get; private set; }

    private readonly ExhibitionMemberRole _role;

    public DateTime JoinedDate { get; private set; }

    private bool _isActive;

    private DateTime? _leaveDate;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ExhibitionMember()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    private ExhibitionMember(
        ExhibitionId exhibitionId,
        MemberId memberId,
        ExhibitionMemberRole role)
    {
        ExhibitionId = exhibitionId;
        MemberId = memberId;
        _role = role;
        JoinedDate = DateTime.Now;
        _isActive = true;

        AddDomainEvent(new NewExhibitionMemberJoinedDomainEvent(ExhibitionId, MemberId, _role));
    }

    public static ExhibitionMember CreateNew(
        ExhibitionId exhibitionId,
        MemberId memberId,
        ExhibitionMemberRole role)
    {
        return new ExhibitionMember(exhibitionId, memberId, role);
    }

    public void Leave()
    {
        _isActive = false;
        _leaveDate = DateTime.Now;

        AddDomainEvent(new ExhibitionMemberLeftGroupDomainEvent(ExhibitionId, MemberId));
    }

    public bool IsMember(MemberId memberId)
    {
        return _isActive && MemberId == memberId;
    }

    public bool IsOrganizer(MemberId memberId)
    {
        return IsMember(memberId) && _role == ExhibitionMemberRole.Organizer;
    }
}