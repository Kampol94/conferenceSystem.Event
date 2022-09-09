using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.ExhibitionProposals.Events;

public class ExhibitionProposedDomainEvent : DomainEventBase
{
    public ExhibitionProposedDomainEvent(
        ExhibitionProposalId exhibitionProposalId,
        string name,
        string description,
        MemberId proposalUserId,
        DateTime proposalDate)
    {
        ExhibitionProposalId = exhibitionProposalId;
        Name = name;
        Description = description;
        ProposalDate = proposalDate;
        ProposalUserId = proposalUserId;
    }

    public ExhibitionProposalId ExhibitionProposalId { get; }

    public string Name { get; }

    public string Description { get; }

    public MemberId ProposalUserId { get; }

    public DateTime ProposalDate { get; }
}