using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Exhibitions.Events;

public class ExhibitionCreatedDomainEvent : DomainEventBase
{
    public ExhibitionId ExhibitionId { get; }

    public MemberId CreatorId { get; }

    public ExhibitionCreatedDomainEvent(ExhibitionId exhibitionId, MemberId creatorId)
    {
        ExhibitionId = exhibitionId;
        CreatorId = creatorId;
    }
}
