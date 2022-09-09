using CompanyName.MyMeetings.Modules.Meetings.Domain.ExhibitionProposals.Events;
using EventService.Domain.Contracts;
using EventService.Domain.ExhibitionProposals.Events;
using EventService.Domain.ExhibitionProposals.Rules;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.ExhibitionProposals;

public class ExhibitionProposal : BaseEntity
{
    public ExhibitionProposalId Id { get; private set; }

    private readonly string _name;

    private readonly string _description;

    private readonly DateTime _proposalDate;

    private readonly MemberId _proposalUserId;

    private ExhibitionProposalStatus _status;

    public Exhibition CreateExhibition()
    {
        return Exhibition.CreateBasedOnProposal(Id, _name, _description, _proposalUserId);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ExhibitionProposal()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        // Only for EF.
    }

    private ExhibitionProposal(
        string name,
        string description,
        MemberId proposalUserId)
    {
        Id = new ExhibitionProposalId(Guid.NewGuid());
        _name = name;
        _description = description;
        _proposalUserId = proposalUserId;
        _proposalDate = DateTime.Now;
        _status = ExhibitionProposalStatus.InVerification;

        this.AddDomainEvent(new ExhibitionProposedDomainEvent(Id, _name, _description, proposalUserId, _proposalDate));
    }

    public static ExhibitionProposal ProposeNew(
        string name,
        string description,
        MemberId proposalMemberId)
    {
        return new ExhibitionProposal(name, description, proposalMemberId);
    }

    public void Accept()
    {
        CheckRule(new ExhibitionProposalCannotBeAcceptedMoreThanOnceRule(_status));

        _status = ExhibitionProposalStatus.Accepted;

        this.AddDomainEvent(new ExhibitionProposalAcceptedDomainEvent(Id));
    }
}
