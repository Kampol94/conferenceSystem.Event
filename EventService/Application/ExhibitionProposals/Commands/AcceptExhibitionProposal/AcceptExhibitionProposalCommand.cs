using EventService.Application.Contracts.Commands;

namespace EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;

public class AcceptExhibitionProposalCommand : CommandBase
{
    public Guid ExhibitionProposalId { get; }

    public AcceptExhibitionProposalCommand(Guid id, Guid exhibitionProposalId)
        : base(id)
    {
        ExhibitionProposalId = exhibitionProposalId;
    }
}