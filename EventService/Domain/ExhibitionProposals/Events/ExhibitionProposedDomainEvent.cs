using EventService.Domain.Contracts;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Members;

namespace CompanyName.MyMeetings.Modules.Meetings.Domain.ExhibitionProposals.Events;

public class ExhibitionProposedDomainEvent : DomainEventBase
{
    public ExhibitionProposedDomainEvent(
        ExhibitionProposalId exhibitionProposalId,
        string name,
        string description,
        MemberId proposalUserId,
        DateTime proposalDate)
    {
        this.ExhibitionProposalId = exhibitionProposalId;
        this.Name = name;
        this.Description = description;
        this.ProposalDate = proposalDate;
        this.ProposalUserId = proposalUserId;
    }

    public ExhibitionProposalId ExhibitionProposalId { get; }

    public string Name { get; }

    public string Description { get; }

    public MemberId ProposalUserId { get; }

    public DateTime ProposalDate { get; }
}