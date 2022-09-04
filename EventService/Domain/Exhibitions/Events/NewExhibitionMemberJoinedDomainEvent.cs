using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Events;

public class NewExhibitionMemberJoinedDomainEvent : DomainEventBase
{
    public ExhibitionId ExhibitionId { get; }

    public MemberId MemberId { get; }

    public ExhibitionMemberRole Role { get; }

    public NewExhibitionMemberJoinedDomainEvent(ExhibitionId exhibitionId, MemberId memberId, ExhibitionMemberRole role)
    {
        ExhibitionId = exhibitionId;
        MemberId = memberId;
        Role = role;
    }
}
