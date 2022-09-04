using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Events;

public class ExhibitionMemberLeftGroupDomainEvent : DomainEventBase
{
    public ExhibitionMemberLeftGroupDomainEvent(ExhibitionId exhibitionId, MemberId memberId)
    {
        ExhibitionId = exhibitionId;
        MemberId = memberId;
    }

    public ExhibitionId ExhibitionId { get; }

    public MemberId MemberId { get; }
}