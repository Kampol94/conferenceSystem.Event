using EventService.Domain.Contracts;

namespace EventService.Domain.ExhibitionProposals.Events;

public class ExhibitionProposalAcceptedDomainEvent : DomainEventBase
{
    public ExhibitionProposalId ExhibitionProposalId { get; }

    public ExhibitionProposalAcceptedDomainEvent(ExhibitionProposalId exhibitionProposalId)
    {
        ExhibitionProposalId = exhibitionProposalId;
    }
}