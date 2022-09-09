using EventService.Application.Contracts.Commands;
using EventService.Domain.ExhibitionProposals;

namespace EventService.Application.Exhibition.Commands.CreateNewExhibition;

public class CreateNewExhibitionCommand : CommandBase
{
    public CreateNewExhibitionCommand(Guid id, ExhibitionProposalId ExhibitionProposalId)
        : base(id)
    {
        this.ExhibitionProposalId = ExhibitionProposalId;
    }

    public ExhibitionProposalId ExhibitionProposalId { get; }
}